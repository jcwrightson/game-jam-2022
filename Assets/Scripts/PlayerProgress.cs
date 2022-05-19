using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{

    public int RageMeter;

    public int Score;

    public Text ScoreText;

    public Text RageText;

    // Start is called before the first frame update
    void Start()
    {
        RageMeter = 0;
        Score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void UpdateScore(int value)
    {
        Score += value;
        ScoreText.text = Score.ToString();
    }

    public void AddRage(int value)
    {
        RageMeter += value;
        RageText.text = RageMeter.ToString();
    }

    public void CalmRage(int value)
    {
        RageMeter -= value;
        RageText.text = RageMeter.ToString();
    }
}
