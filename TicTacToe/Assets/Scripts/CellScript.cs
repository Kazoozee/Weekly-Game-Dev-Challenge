using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour {

    public GameObject GameCordinator;
    public Sprite circle;
    public Sprite cross;
    private SpriteRenderer cellSprite;
    private bool cellUsed = false;
    private bool gameOver = false;

    private void Start()
    {
        cellSprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1") && cellUsed == false && gameOver == false && GameCordinator.GetComponent<GameCordinator>().aiMoving == false)
        {
            MarkCell();
        }
    }

    public void MarkCell()
    {
        if (GameCordinator.GetComponent<GameCordinator>().pOneTurn == true)
        {
            cellSprite.sprite = circle;
        }
        else
        {
            cellSprite.sprite = cross;
        }
        cellUsed = true;
        GameCordinator.SendMessage("CellClicked", gameObject.name);
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void ResetCell()
    {
        cellSprite.sprite = null;
        cellUsed = false;
        gameOver = false;
    }
}
