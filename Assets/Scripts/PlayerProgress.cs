using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public int RageMeter;

    public TextMeshPro textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro.text = "Rage Level: " + RageMeter.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textmeshPro.text = "Rage Level: " + RageMeter.ToString();
    }
}
