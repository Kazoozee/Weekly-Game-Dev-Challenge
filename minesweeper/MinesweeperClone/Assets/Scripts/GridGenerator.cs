using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour {

    public AudioClip gameOverSound;
    public AudioClip gameWonSound;
    private AudioSource source;
    public GameObject cell;
    public Camera mainCamera;
    public Text statusText;
    public GameObject[] oldCells;
    public int tempGridSizeX = 10;
    public int tempGridSizeY = 10;
    public int tempBombChance = 3;
    public int gridSizeX = 10;
    public int gridSizeY = 10;
    public int bombChance = 10;
    public bool gameOver = false;
    private bool tempWinState = true;
    public int[,] map;
    public int[,] boardState;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        // Generate a map of the game board. 9 represents a bomb in that location.
        map = new int[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                int tempIndex = Random.Range(0, bombChance);
                if (tempIndex == 0)
                {
                    map[i, j] = 9;
                }
                else
                {
                    map[i, j] = 0;
                }
            }
        }
        boardState = map;

        // Run through the cells again and count up the nearby bombs.
        for (int k = 0; k < gridSizeX; k++)
        {
            for (int l = 0; l < gridSizeY; l++)
            {
                int bombCount = 0;
                if (map[k, l] != 9)
                {
                    if (k > 0 && l > 0)
                    {
                        if (map[k - 1, l - 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (k > 0)
                    {
                        if (map[k - 1, l] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (k > 0 && l < gridSizeY - 1)
                    {
                        if (map[k - 1, l + 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (l < gridSizeY - 1)
                    {
                        if (map[k, l + 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (k < gridSizeX - 1 && l < gridSizeY - 1)
                    {
                        if (map[k + 1, l + 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (k < gridSizeX - 1)
                    {
                        if (map[k + 1, l] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (k < gridSizeX - 1 && l > 0)
                    {
                        if (map[k + 1, l - 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    if (l > 0)
                    {
                        if (map[k, l - 1] == 9)
                        {
                            bombCount++;
                        }
                    }
                    map[k, l] = bombCount;
                }
            }
        }
        // Build Game Board
        for (int m = 0; m < gridSizeX; m++)
        {
            for (int n = 0; n < gridSizeY; n++)
            {
                Instantiate(cell, new Vector3(m, n), Quaternion.identity);
            }
        }
    }

    private void LateUpdate()
    {
        // Check win condition
        tempWinState = true;
        for (int o = 0; o < gridSizeX; o++)
        {
            for (int p = 0; p < gridSizeY; p++)
            {
                if (boardState[o,p] != 9)
                {
                    tempWinState = false;
                }
            }
        }
        if (tempWinState == true)
        {
            GameWon();
        }
    }

    public void GameLost()
    {
        source.PlayOneShot(gameOverSound);
        gameOver = true;
        oldCells = GameObject.FindGameObjectsWithTag("Cell");
        for ( int r = 0; r < oldCells.Length; r++)
        {
            oldCells[r].SendMessage("GameLost");
        }
        statusText.text = "You Lose! Try again!";
    }

    private void GameWon()
    {
        if (gameOver == false)
        {
            source.PlayOneShot(gameWonSound);
        } 
        gameOver = true;
        statusText.text = "You Win!";
    }

    public void PlayAgain()
    {
        statusText.text = "Welcome to Kazoozee's Minesweeper Clone!";
        gameOver = false;
        gridSizeX = tempGridSizeX;
        gridSizeY = tempGridSizeY;
        float gridSizeXFloat = (float)gridSizeX;
        float gridSizeYFloat = (float)gridSizeY;
        bombChance = 10 - tempBombChance;
        oldCells = GameObject.FindGameObjectsWithTag("Cell");

        if (gridSizeX >= gridSizeY)
        {
            mainCamera.orthographicSize = (gridSizeXFloat * 0.57f);
            mainCamera.transform.position = new Vector3(gridSizeXFloat * 0.75f, (gridSizeXFloat - 2) * 0.5f ,mainCamera.transform.position.z);
        }
        if (gridSizeY > gridSizeX)
        {
            mainCamera.orthographicSize = (gridSizeYFloat * 0.57f);
            mainCamera.transform.position = new Vector3(gridSizeYFloat * 0.75f, (gridSizeYFloat - 2) * 0.5f, mainCamera.transform.position.z);
        }
        for (int q = 0; q < oldCells.Length; q++)
        {
            Destroy(oldCells[q]);
        }
        GenerateBoard();
    }

    public void AdjustGridSizeX(Slider slider)
    {
        tempGridSizeX = Mathf.RoundToInt(slider.value);
    }

    public void AdjustGridSizeY(Slider slider)
    {
        tempGridSizeY = Mathf.RoundToInt(slider.value);
    }

    public void AdjustBombDensity(Slider slider)
    {
        tempBombChance = Mathf.RoundToInt(slider.value);
    }
}
