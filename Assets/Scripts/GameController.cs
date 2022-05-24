using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static PlayerProgress progress;

    void Awake()
    {

        Debug.Log(PlayerProgress.Difficulty.ToString());
        Debug.Log(PlayerProgress.Score.ToString());
        Debug.Log(PlayerProgress.Rage.ToString());
    }
}
