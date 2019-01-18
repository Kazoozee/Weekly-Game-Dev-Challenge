using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCoordinator : MonoBehaviour {

    public bool hold = false;
    public GameObject cardPreFab;
    public Text tryCountText;
    private int tryCount = 0;
    public int cardsX = 6;
    public int cardsY = 4;
    private int tempCardCount;
    private float dealDelay = 0.1f;
    private int flippedCardCount = 0;
    private int cardCount;
    private int matchesFound = 0;
    public int cardTypes = 4;
    private int cardsPerType;   
    List<int> cards = new List<int>();
    List<int> shuffledList = new List<int>();
    List<GameObject> flippedCards = new List<GameObject>();
    public int[,] board;

    void Start () {
        board = new int[cardsX, cardsY];
        cardCount = cardsX * cardsY;
        cardsPerType = cardCount / cardTypes;
        Shuffle();
	}

    private void LateUpdate()
    {
        tryCountText.text = tryCount.ToString();
        if (flippedCardCount >= 2)
        {
            hold = true;
        }
    }

    public void cardClicked(GameObject card)
    {
        flippedCardCount++;
        flippedCards.Add(card);
        if (flippedCardCount == 2)
        {
            if (flippedCards[0].GetComponent<CardScript>().cardID == flippedCards[1].GetComponent<CardScript>().cardID)
            {
                flippedCardCount = 0;
                flippedCards.Clear();
                hold = false;
                tryCount++;
                matchesFound++;
            }
            else
            {
                hold = true;
                tryCount++;
                StartCoroutine(UnflipCards());
            }
            if (matchesFound >= cardCount / 2)
            {
                PlayerPrefs.SetInt("guessCount", tryCount);
                StartCoroutine(GameOverScreen());
            }
        }
    }

    IEnumerator UnflipCards()
    {
        yield return new WaitForSeconds(1.2f);
        foreach (GameObject Card in flippedCards)
        {
            Card.GetComponent<CardScript>().unflipping = true;
        }
        flippedCardCount = 0;
        flippedCards.Clear();
    }

    IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
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
