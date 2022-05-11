using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private PlayerProgress player; 

    private LevelController level;

    public int ScoreValue = 1;

    public int RageValue = 1;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerProgress>();
        player.RageMeter = 100;
        player.Score = 0;

        level = transform.parent.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        level.CountCollision();

        // Hit
        if (collision.gameObject.layer == 3 & player.RageMeter != 0)
        {
            player.CalmRage (RageValue);
            player.UpdateScore (ScoreValue);
        }

        // Miss
        if (collision.gameObject.layer == 7 & player.RageMeter != 100)
        {
            player.AddRage (RageValue);
        }

        Destroy (gameObject);
    }
}
