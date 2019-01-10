using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour {

    public int cardsX = 6;
    public int cardsY = 4;
    public int cardTypes = 4;
    public int[,] board;

    void Start () {
        BuildGameBoard();
	}

    private void BuildGameBoard()
    {
        int topCard = 0;
        for (int i = 0; i < cardsX * cardsY; i++)
        {

            if (topCard >= cardTypes)
            {
                topCard = 0;
            }
        }
    }
}
