using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static int score = 0;
    public Text ScoreText;

    void Start()
    {
        score = PlayerProgress.Score; //get the PlayerPrefs value
        ScoreText.text = score.ToString(); //write the score back to text to display on GameOver screen
    }

    void Update()
    {
        
    }
}
