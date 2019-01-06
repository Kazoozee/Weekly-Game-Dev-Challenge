/*
 * Feature Request;
 * 
 * Build ideal play script
 * 
 * currently at line 774             if (moveList[0] == 4)
 * 
 * Build in lower dificalty by implimenting a percent posibility that the AI will deviate from ideal play
 * 
 * Bugs:
 * 
 * If the AI runs into a tie it does not make a final move because the ai runs after the win condition. This results in the player who moves first not flipping in this situation.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCordinator : MonoBehaviour {

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;

    public List<GameObject> cellList;

    public Text StatusText;
    public Text PlayerTwoText;
    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;
    public Text TiedGamesText;

    public int[] gameBoard = new int[] { 0,0,0,0,0,0,0,0,0 };
    private int moveCount = 0;
    public int[] moveList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public bool pOneTurn = true;
    private bool pOneWentFirst = true;
    private bool gameOver = false;
    private bool aiEnabled = false;
    public bool aiMoving = false;
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private int tiedGamesCount = 0;

    void Start()
    {
        cellList = new List<GameObject> { one, two, three, four, five, six, seven, eight, nine };
        UpdateScoreboard();
    }

    private void AIMove()
    {
        if (pOneWentFirst == true)
        {
            if (moveList[0] == 1)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {
                    if (moveList[2] == 2)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                            }
                            if (moveList[4] == 7)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                                else
                                {
                                    if (moveList[6] == 6)
                                    {
                                        if(moveCount == 7)
                                        {
                                            StartCoroutine(AISendMessage(eight));
                                        }
                                    }
                                    if (moveList[6] == 7 || moveList[6] == 8)
                                    {
                                        if(moveCount == 7)
                                        {
                                            StartCoroutine(AISendMessage(six));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 3)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 7 || moveList[4] == 4 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(eight));
                            }
                            if (moveList[4] == 8)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                                else
                                {
                                    if (moveList[6] == 6)
                                    {
                                        if (moveCount == 7)
                                        {
                                            StartCoroutine(AISendMessage(nine));
                                        }
                                    }
                                    if (moveList[6] == 7 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(six));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 4)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(seven));
                        }
                        else
                        {
                            if (moveList[4] == 2 || moveList[4] == 6 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(three));
                                }                               
                            }
                            if (moveList[4] == 3)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(two));
                                }
                                else
                                {
                                    if (moveList[6] == 6 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                    if (moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(six));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 6)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(eight));
                        }
                        else
                        {
                            if (moveList[4] == 2)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(three));
                                }
                                else
                                {
                                    if (moveList[6] == 4 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                    if (moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                }
                            }
                            if (moveList[4] == 3 || moveList[4] == 4 || moveList[4] == 7 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(two));
                            }
                        }
                    }
                    if (moveList[2] == 7)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(four));
                        }
                        else
                        {
                            if (moveList[4] == 2 || moveList[4] == 3 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(six));
                            }
                            if (moveList[4] == 6)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(two));
                                }
                                if (moveList[6] == 3 || moveList[6] == 9)
                                {
                                    StartCoroutine(AISendMessage(eight));
                                }
                                if (moveList[6] == 8)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                            }
                        }
                    }
                    if (moveList[2] == 8)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(six));
                        }
                        else
                        {
                            if (moveList[4] == 2 || moveList[4] == 3 || moveList[4] == 7 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(four));
                            }
                            if (moveList[4] == 4)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                                else
                                {
                                    if (moveList[6] == 2 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(three));
                                    }
                                    if (moveList[6] == 3)
                                    {
                                        StartCoroutine(AISendMessage(two));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 9)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                        else
                        {
                            if (moveList[4] == 3 || moveList[4] == 4 || moveList[4] == 7 || moveList[4] == 7)
                            {
                                StartCoroutine(AISendMessage(eight));
                            }
                            if (moveList[4] == 8)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                                if (moveList[6] == 3)
                                {
                                    StartCoroutine(AISendMessage(six));
                                }
                                if (moveList[6] == 4 || moveList[6] == 6)
                                {
                                    StartCoroutine(AISendMessage(three));
                                }
                            }
                        }
                    }
                }
            }
            if (moveList[0] == 2)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {
                    if (moveList[2] == 1)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(seven));
                            }
                            if (moveList[4] == 7)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                                else
                                {
                                    if (moveList[6] == 6)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                    if (moveList[6] == 8 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(nine));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 3)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(nine));
                            }
                            if (moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(six));
                                }
                                else
                                {
                                    if (moveList[6] == 4)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                    if (moveList[6] == 7 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 4)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 6 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(seven));
                            }
                            if (moveList[4] == 7)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(one));
                                }
                                else
                                {
                                    if (moveList[6] == 6 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(nine));
                                    }
                                    if (moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 6)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {
                            if (moveList[4] == 3 || moveList[4] == 4 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(nine));
                            }
                            if (moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(three));
                                }
                                else
                                {
                                    if (moveList[6] == 4 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                    if (moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 7)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(six));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 3 || moveList[4] == 8 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(four));
                            }
                            if (moveList[4] == 4)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(one));
                                }
                                else
                                {
                                    if (moveList[6] == 6 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(nine));
                                    }
                                    if (moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 8)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {
                            if (moveList[4] == 3 || moveList [4] == 4 || moveList [4] == 6 || moveList[4] == 7)
                            {
                                StartCoroutine(AISendMessage(nine));
                            }
                            if (moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                                else
                                {
                                    if (moveList[6] == 3)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                    if (moveList[6] == 4 || moveList[6] == 6)
                                    {
                                        StartCoroutine(AISendMessage(three));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 9)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(four));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 3 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(six));
                            }
                            if (moveList[4] == 6)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(three));
                                }
                                else
                                {
                                    if (moveList[6] == 1 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                    if (moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (moveList[0] == 3)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {
                    if (moveList[2] == 1)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 7 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(eight));
                            }
                            if (moveList[4] == 8)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                                else
                                {
                                    if (moveList[6] == 6)
                                    {
                                        StartCoroutine(AISendMessage(nine));
                                    }
                                    if (moveList[6] == 7 || moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(six));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 2)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {
                            if (moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(nine));
                            }
                            if (moveList[4] == 9)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(six));
                                }
                                else
                                {
                                    if (moveList[6] == 4)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                    if (moveList[6] == 7 || moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 4)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(eight));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 6 || moveList[4] == 7 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(two));
                            }
                            if (moveList[4] == 2)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(one));
                                }
                                else
                                {
                                    if (moveList[6] == 6 || moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(nine));
                                    }
                                    if (moveList[6] == 9)
                                    {
                                        StartCoroutine(AISendMessage(six));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 6)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(nine));
                        }
                        else
                        {
                            if (moveList[4] == 1)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(two));
                                }
                                else
                                {
                                    if (moveList[6] == 4 || moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                    if (moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                }
                            }
                            if (moveList[4] == 2 || moveList[4] == 4 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(one));
                            }
                        }
                    }
                    if (moveList[2] == 7)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 4 || moveList[4] == 6 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(eight));
                            }
                            if (moveList[4] == 8)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                                else
                                {
                                    if (moveList[6] == 1)
                                    {
                                        StartCoroutine(AISendMessage(four));
                                    }
                                    if (moveList[6] == 4 || moveList[6] == 6)
                                    {
                                        StartCoroutine(AISendMessage(one));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 8)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(four));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 2 || moveList[4] == 7 || moveList[4] == 9)
                            {
                                StartCoroutine(AISendMessage(six));
                            }
                            if (moveList[4] == 6)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                                else
                                {
                                    if (moveList[6] == 1)
                                    {
                                        StartCoroutine(AISendMessage(two));
                                    }
                                    if (moveList[6] == 2 || moveList[6] == 7)
                                    {
                                        StartCoroutine(AISendMessage(one));
                                    }
                                }
                            }
                        }
                    }
                    if (moveList[2] == 9)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(six));
                        }
                        else
                        {
                            if (moveList[4] == 1 || moveList[4] == 2 || moveList[4] == 7 || moveList[4] == 8)
                            {
                                StartCoroutine(AISendMessage(four));
                            }
                            if (moveList[4] == 4)
                            {
                                if (moveCount == 5)
                                {
                                    StartCoroutine(AISendMessage(two));
                                }
                                else
                                {
                                    if (moveList[6] == 1 || moveList[6] == 1)
                                    {
                                        StartCoroutine(AISendMessage(eight));
                                    }
                                    if (moveList[6] == 8)
                                    {
                                        StartCoroutine(AISendMessage(seven));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (moveList[0] == 4)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {
                    if (moveList[2] == 1)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(seven));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 2)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 3)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(eight));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 6)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 7)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 8)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(one));
                        }
                        else
                        {

                        }
                    }
                    if (moveList[2] == 9)
                    {
                        if (moveCount == 3)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                        else
                        {

                        }
                    }
                }
            }
            if (moveList[0] == 5)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(one));
                }
                else
                {

                }
            }
            if (moveList[0] == 6)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {

                }
            }
            if (moveList[0] == 7)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {

                }
            }
            if (moveList[0] == 8)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {

                }
            }
            if (moveList[0] == 9)
            {
                if (moveCount == 1)
                {
                    StartCoroutine(AISendMessage(five));
                }
                else
                {

                }
            }
        }
        else
        {
            if (moveCount == 0)
            {
                StartCoroutine(AISendMessage(one));
            }
            else
            {
                if (moveList[1] == 2)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(four));
                    }
                    if (moveList[3] == 3 || moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 8 || moveList[3] == 9)
                    {
                        StartCoroutine(AISendMessage(seven));
                    }
                    if (moveList[3] == 7)
                    {
                        if (moveCount == 4)
                        {
                            StartCoroutine(AISendMessage(five));
                        }
                        else
                        {
                            if (moveList[5] == 3 || moveList[5] == 8 || moveList[5] == 9)
                            {
                                StartCoroutine(AISendMessage(six));
                            }
                            if (moveList[5] == 6)
                            {
                                StartCoroutine(AISendMessage(nine));
                            }
                        }
                    }
                }
                if (moveList[1] == 3)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(four));
                    }
                    else
                    {
                        if (moveList[3] == 2 || moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 8 || moveList[3] == 9)
                        {
                            StartCoroutine(AISendMessage(seven));
                        }
                        if (moveList[3] == 7)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(five));
                            }
                            else
                            {
                                if (moveList[5] == 2 || moveList[5] == 8 || moveList[5] == 9)
                                {
                                    StartCoroutine(AISendMessage(six));
                                }
                                if (moveList[5] == 6)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                            }
                        }
                    }
                }
                if (moveList[1] == 4)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(two));
                    }
                    else
                    {
                        if (moveList[3] == 3)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(five));
                            }
                            else
                            {
                                if (moveList[5] == 6 || moveList[5] == 7 || moveList[5] == 9)
                                {
                                    StartCoroutine(AISendMessage(eight));
                                }
                                if (moveList[5] == 8)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                            }
                        }
                        if (moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 7 || moveList[3] == 8 || moveList[3] == 9)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                    }
                }
                if (moveList[1] == 5)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(two));
                    }
                    else
                    {
                        if (moveList[3] == 3)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(seven));
                            }
                            else
                            {
                                if (moveList[5] == 4)
                                {
                                    if (moveCount == 6)
                                    {
                                        StartCoroutine(AISendMessage(six));
                                    }
                                    else
                                    {
                                        if (moveList[7] == 8)
                                        {
                                            StartCoroutine(AISendMessage(nine));
                                        }
                                        if (moveList[7] == 9)
                                        {
                                            StartCoroutine(AISendMessage(eight));
                                        }
                                    }
                                }
                                if (moveList[5] == 6 || moveList[5] == 8 || moveList[5] == 9)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                            }
                        }
                        if (moveList[3] == 4 || moveList[3] == 6 || moveList[3] == 7 || moveList[3] == 8 || moveList[3] == 9)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                    }
                }
                if (moveList[1] == 6)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(five));
                    }
                    else
                    {
                        if (moveList[3] == 2 || moveList[3] == 3 || moveList[3] == 4 || moveList[3] == 7 || moveList[3] == 8)
                        {
                            StartCoroutine(AISendMessage(nine));
                        }
                        if (moveList[3] == 9)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(three));
                            }
                            else
                            {
                                if (moveList[5] == 2)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                                if (moveList[5] == 4 || moveList[5] == 7 || moveList[5] == 8)
                                {
                                    StartCoroutine(AISendMessage(two));
                                }
                            }
                        }
                    }
                }
                if (moveList[1] == 7)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(two));
                    }
                    else
                    {
                        if (moveList[3] == 3)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(five));
                            }
                            else
                            {
                                if (moveList[5] == 4 || moveList[5] == 6 || moveList[5] == 9)
                                {
                                    StartCoroutine(AISendMessage(eight));
                                }
                                if (moveList[5] == 8)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                            }
                        }
                        if (moveList[3] == 4 || moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 8 || moveList[3] == 9)
                        {
                            StartCoroutine(AISendMessage(three));
                        }
                    }
                }
                if (moveList[1] == 8)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(three));
                    }
                    else
                    {
                        if (moveList[3] == 2)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(five));
                            }
                            else
                            {
                                if (moveList[5] == 4 || moveList[5] == 6 || moveList[5] == 9)
                                {
                                    StartCoroutine(AISendMessage(seven));
                                }
                                if (moveList[5] == 7)
                                {
                                    StartCoroutine(AISendMessage(nine));
                                }
                            }
                        }
                        if (moveList[3] == 4 || moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 7 || moveList[3] == 9)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                    }
                }
                if (moveList[1] == 9)
                {
                    if (moveCount == 2)
                    {
                        StartCoroutine(AISendMessage(three));
                    }
                    else
                    {
                        if (moveList[3] == 2)
                        {
                            if (moveCount == 4)
                            {
                                StartCoroutine(AISendMessage(seven));
                            }
                            else
                            {
                                if (moveList[5] == 4)
                                {
                                    StartCoroutine(AISendMessage(five));
                                }
                                if (moveList[5] == 5 || moveList[5] == 6 || moveList[5] == 8)
                                {
                                    StartCoroutine(AISendMessage(four));
                                }
                            }
                        }
                        if (moveList[3] == 4 || moveList[3] == 5 || moveList[3] == 6 || moveList[3] == 7)
                        {
                            StartCoroutine(AISendMessage(two));
                        }
                    }
                }
            }
        }
    }

    IEnumerator AISendMessage(GameObject cell)
    {
        aiMoving = true;
        yield return new WaitForSeconds(0.5f);
        cell.SendMessage("MarkCell");
        aiMoving = false;
    }

    public void CellClicked(string cell)
    {
        // Load turn into gameBoard array
        Debug.Log("cellClicked called with " + cell);
        int tempTurn;
        if (pOneTurn == true)
        {
            tempTurn = 1;
        }
        else
        {
            tempTurn = 2;
        }
        if (cell == "one")
        {
            gameBoard[0] = tempTurn;
            moveList[moveCount] = 1;
        }
        if (cell == "two")
        {
            gameBoard[1] = tempTurn;
            moveList[moveCount] = 2;
        }
        if (cell == "three")
        {
            gameBoard[2] = tempTurn;
            moveList[moveCount] = 3;
        }
        if (cell == "four")
        {
            gameBoard[3] = tempTurn;
            moveList[moveCount] = 4;
        }
        if (cell == "five")
        {
            gameBoard[4] = tempTurn;
            moveList[moveCount] = 5;
        }
        if (cell == "six")
        {
            gameBoard[5] = tempTurn;
            moveList[moveCount] = 6;
        }
        if (cell == "seven")
        {
            gameBoard[6] = tempTurn;
            moveList[moveCount] = 7;
        }
        if (cell == "eight")
        {
            gameBoard[7] = tempTurn;
            moveList[moveCount] = 8;
        }
        if (cell == "nine")
        {
            gameBoard[8] = tempTurn;
            moveList[moveCount] = 9;
        }
        moveCount++;
        pOneTurn = !pOneTurn;
        WinCheck();
        UpdateScoreboard();
    }
    
    public void WinCheck()
    {
        if(gameBoard[0] == 1 && gameBoard[1] == 1 && gameBoard[2] == 1)
        {
            POneWin();
        }
        if (gameBoard[3] == 1 && gameBoard[4] == 1 && gameBoard[5] == 1)
        {
            POneWin();
        }
        if (gameBoard[6] == 1 && gameBoard[7] == 1 && gameBoard[8] == 1)
        {
            POneWin();
        }
        if (gameBoard[0] == 1 && gameBoard[3] == 1 && gameBoard[6] == 1)
        {
            POneWin();
        }
        if (gameBoard[1] == 1 && gameBoard[4] == 1 && gameBoard[7] == 1)
        {
            POneWin();
        }
        if (gameBoard[2] == 1 && gameBoard[5] == 1 && gameBoard[8] == 1)
        {
            POneWin();
        }
        if (gameBoard[0] == 1 && gameBoard[4] == 1 && gameBoard[8] == 1)
        {
            POneWin();
        }
        if (gameBoard[2] == 1 && gameBoard[4] == 1 && gameBoard[6] == 1)
        {
            POneWin();
        }
        if (gameBoard[0] == 2 && gameBoard[1] == 2 && gameBoard[2] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[3] == 2 && gameBoard[4] == 2 && gameBoard[5] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[6] == 2 && gameBoard[7] == 2 && gameBoard[8] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[0] == 2 && gameBoard[3] == 2 && gameBoard[6] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[1] == 2 && gameBoard[4] == 2 && gameBoard[7] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[2] == 2 && gameBoard[5] == 2 && gameBoard[8] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[0] == 2 && gameBoard[4] == 2 && gameBoard[8] == 2)
        {
            PTwoWin();
        }
        if (gameBoard[2] == 2 && gameBoard[4] == 2 && gameBoard[6] == 2)
        {
            PTwoWin();
        }
        if (gameOver == false && gameBoard[0] != 0 && gameBoard[1] != 0 && gameBoard[2] != 0 && gameBoard[3] != 0 && gameBoard[4] != 0 && gameBoard[5] != 0 && gameBoard[6] != 0 && gameBoard[7] != 0)
        {
            GameTied();
        }
        if (gameOver == false && aiEnabled == true && pOneTurn == false)
        {
            AIMove();
        }
    }

    public void POneWin()
    {
        if (pOneWentFirst == false)
        {
            pOneTurn = !pOneTurn;
        }
        StatusText.text = "Player One Wins This Round!";
        playerOneScore++;
        gameOver = true;
        foreach(GameObject cell in cellList)
        {
            cell.SendMessage("GameOver");
        }
    }

    public void PTwoWin()
    {
        if (pOneWentFirst == true)
        {
            pOneTurn = !pOneTurn;
        }
        if (aiEnabled == false)
        {
            StatusText.text = "Player Two Wins This Round!";
        }
        else
        {
            StatusText.text = "The AI Beat you this round!";
        }
        playerTwoScore++;
        gameOver = true;
        foreach (GameObject cell in cellList)
        {
            cell.SendMessage("GameOver");
        }
    }

    public void GameTied()
    {
        StatusText.text = "This Round Was A Tie!";
        tiedGamesCount++;
        gameOver = true;
    }

    private void UpdateScoreboard()
    {
        if (gameOver == false)
        {
            if (pOneTurn == true)
            {
                StatusText.text = "It is Player One's Turn!";
            }
            else
            {
                if (aiEnabled == true)
                {
                    StatusText.text = "The AI is Thinking!";
                }
                else
                {
                    StatusText.text = "It is Player Two's Turn!";
                }    
            }
        }
        if (aiEnabled == false)
        {
            PlayerTwoText.text = "Player Two";
        }
        else
        {
            PlayerTwoText.text = "AI Player";
        }
        PlayerOneScoreText.text = playerOneScore.ToString();
        PlayerTwoScoreText.text = playerTwoScore.ToString();
        TiedGamesText.text = tiedGamesCount.ToString();
        
    }

    public void PlayAgain()
    {
        gameOver = false;
        if (pOneTurn == true)
        {
            pOneWentFirst = true;
        }
        else
        {
            pOneWentFirst = false;
        }
        gameBoard = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        moveList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        moveCount = 0;
        foreach (GameObject cell in cellList)
        {
            cell.SendMessage("ResetCell");
        }
        UpdateScoreboard();
        if (pOneTurn == false && aiEnabled == true)
        {
            AIMove();
        }
    }

    public void ResetScores()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        tiedGamesCount = 0;
        UpdateScoreboard();
    }

    public void AIEnableToggle(Toggle toggle)
    {
        aiEnabled = toggle.isOn;
    }
}
