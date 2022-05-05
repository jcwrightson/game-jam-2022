using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public float speed;

    private int totalBlocks = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalBlocks = transform.childCount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =
            new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z - speed / 10);
    }
}
