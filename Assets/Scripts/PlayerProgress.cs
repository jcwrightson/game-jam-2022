using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public int RageMeter;

    public int Score;

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
    }

    public void AddRage(int value)
    {
        RageMeter += value;
    }

    public void CalmRage(int value)
    {
        RageMeter -= value;
    }
}
