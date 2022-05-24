using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;

    public Text RageText;

    private PlayerProgress progress;

    void FixedUpdate()
    {
        RageText.text = PlayerProgress.Rage.ToString();
        ScoreText.text = PlayerProgress.Score.ToString();
    }
}