using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    private int guessCount;
    private int guessRecord;
    public Text guessText;

	void Start () {
        UpdateText();
	}
	
    private void UpdateText()
    {
        guessCount = PlayerPrefs.GetInt("guessCount");
        guessRecord = PlayerPrefs.GetInt("guessRecord");
        if (guessCount < guessRecord || guessRecord == 0)
        {
            PlayerPrefs.SetInt("guessRecord", guessCount);
            guessRecord = guessCount;
        }
        if (guessCount == 0)
        {
            guessText.text = "Record data reset!\n Click Play Again to set a new record!";
        }
        else
        {
            guessText.text = "Congragulations!\nYou matched all the cards in\n" + guessCount + " guesses!\n Your all time best is \n" + guessRecord + " guesses!";
        }
    }

	public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetRecord()
    {
        PlayerPrefs.DeleteKey("guessCount");
        PlayerPrefs.DeleteKey("guessRecord");
        UpdateText();
    }
}
