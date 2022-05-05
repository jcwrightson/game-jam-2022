using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private PlayerProgress player; // Start is called before the first frame update

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerProgress>();
        player.RageMeter = 100;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        // Weapons Layer
        if (collision.gameObject.layer == 3 & player.RageMeter != 0)
        {
            // Decrease Rage
            player.RageMeter -= 1;
        }

        // RageCollector Layer
        if (collision.gameObject.layer == 7 & player.RageMeter != 100)
        {
            // Increase Rage
            player.RageMeter += 1;
        }

        Destroy (gameObject);
    }
}
