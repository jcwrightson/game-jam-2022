using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public Slider slider;
    public Text RageText;
    public Gradient gradient;
    public Image fill;

    public int RageBarValue;

    private PlayerProgress progress;

    void FixedUpdate()
    {
        RageText.text = PlayerProgress.Rage.ToString();
        ScoreText.text = PlayerProgress.Score.ToString();
        slider.value = PlayerProgress.Rage;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
