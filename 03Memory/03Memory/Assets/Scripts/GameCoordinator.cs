/*
 * Features:
 *      
 *  Animate movement of card position
 *  
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameCoordinator : MonoBehaviour {

    public GameObject cardPreFab;
    public int cardsX = 6;
    public int cardsY = 4;
    private int tempCardCount;
    private float dealDelay = 0.5f;
    private int cardCount;
    public int cardTypes = 4;
    private int cardsPerType;   
    List<int> cards = new List<int>();
    List<int> shuffledList = new List<int>();
    public int[,] board;

    void Start () {
        board = new int[cardsX, cardsY];
        cardCount = cardsX * cardsY;
        cardsPerType = cardCount / cardTypes;
        Shuffle();
	}

    private void Shuffle()
    {
        tempCardCount = 0;
        // Build List of cards and shuffle it
        for (int i = 0; i < cardTypes; i++)
        {
            for (int j = 0; j < cardsPerType; j++)
            {
                cards.Add(i);
            }
        }
        shuffledList = cards.OrderBy(x => Random.value).ToList();
        for (int k = 0; k < cardsX; k++)
        {
            for (int l = 0; l < cardsY; l++)
            {
                board[k, l] = shuffledList[tempCardCount];
                tempCardCount++;
            }
        }
        StartCoroutine(DealCard());
    }

    IEnumerator DealCard()
    {
        for (int i = 0; i < cardsX; i++)
        {
            for (int j = 0; j < cardsY; j++)
            {
                yield return new WaitForSeconds(dealDelay);
                GameObject go = (GameObject)Instantiate(cardPreFab, transform.position, transform.rotation);
                CardScript script = go.GetComponent<CardScript>();
                script.cardID = board[i, j];
                script.positionX = i;
                script.positionY = j;
            }
        }
    }
}
