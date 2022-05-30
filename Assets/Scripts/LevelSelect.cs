using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LevelChoice (int level)
    {
        PlayerProgress.Difficulty = level;
    }
}
