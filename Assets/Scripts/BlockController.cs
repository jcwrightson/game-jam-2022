using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int ScoreValue = 1;

    public int RageValue = 1;

    private LevelController levelControl;

    void Start()
    {
        levelControl = transform.parent.GetComponent<LevelController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Hit
        if (collision.gameObject.layer == 3)
        {
            levelControl.Hit (ScoreValue, RageValue);
        }

        // Miss
        if (collision.gameObject.layer == 7)
        {
            levelControl.Miss (ScoreValue, RageValue);
        }

        Destroy (gameObject);
    }
}
