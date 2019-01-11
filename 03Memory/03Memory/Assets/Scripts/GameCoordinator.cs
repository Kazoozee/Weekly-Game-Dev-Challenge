/*
 * Features:
 *      
 *  Build array from cards in list
 *  
 *  run coroutine to instantiate each card with a small delay between each
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameCoordinator : MonoBehaviour {

    public int cardsX = 6;
    public int cardsY = 4;
    private float dealDelay = 0.5f;
    private int cardCount;
    public int cardTypes = 4;
    private int cardsPerType;   
    List<int> cards = new List<int>();
    List<int> shuffledList = new List<int>();
    public int[,] board;

    void Start () {
        cardCount = cardsX * cardsY;
        cardsPerType = cardCount / cardTypes;
        Shuffle();
	}

    private void Shuffle()
    {
        // Build List of cards and shuffle it
        for (int i = 0; i < cardTypes; i++)
        {
            for (int j = 0; j < cardsPerType; j++)
            {
                cards.Add(i);
            }
        }
        shuffledList = cards.OrderBy(x => Random.value).ToList();
        StartCoroutine(DealCard());
        
    }

    IEnumerator DealCard()
    {
       
        for (int i = 0; i < shuffledList.Count; i++)
        {
            yield return new WaitForSeconds(dealDelay);
            Debug.Log(shuffledList[i]);
        }
    }
}
