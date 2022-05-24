using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress
{
    public static int Rage = 60;

    public static int Score = 0;

    public static int Difficulty = 1;


    public static void ResetProgress(int s = 0, int r = 60)
    {
        Score = s;
        Rage = r;
    }

    public static void IncScore(int value)
    {
        Score += value;
    }

    public static void DecScore(int value)
    {
        Score -= value;
    }

    public static void IncRage(int value)
    {
        Rage += value;
    }

    public static void DecRage(int value)
    {
        if (Rage - value >= 0)
        {
            Rage -= value;
        }
        else
        {
            Rage = 0;
        }
    }

    public static void SelectDifficulty(int value)
    {
        Difficulty = value;
    }
}
