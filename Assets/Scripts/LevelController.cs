using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int difficulty; // 1: Easy, 2: Med, 3: Hard, 4: Insane!!

    public List<GameObject> prefabs;

    private List<Vector3> memo = new List<Vector3>();

    private int collisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < CalculateNoOfPieces(); i++)
        {
            // Pick a random object to spawn
            int idx = UnityEngine.Random.Range(0, prefabs.Count);

            Vector3 pos = buildPosition(i, difficulty);

            Instantiate(prefabs[idx], pos, transform.rotation, transform);
        }
    }

    private Vector3 buildVectorEasy(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-1.5f, 1.5f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 2f); // Vertical
        float z = UnityEngine.Random.Range(2f, 5f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorMed(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-2f, 2f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 2f); // Vertical
        float z = UnityEngine.Random.Range(1f, 3f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorHard(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-2f, 2f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 3f); // Vertical
        float z = UnityEngine.Random.Range(1f, 3f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorInsane(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-2f, 2f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 3f); // Vertical
        float z = UnityEngine.Random.Range(0f, 2f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildPosition(int i, int difficulty)
    {
        Vector3 lastSpawned;
        Vector3 result;

        if (i > 0)
        {
            lastSpawned = memo[i - 1];
        }
        else
        {
            lastSpawned = transform.position;
        }

        switch (difficulty)
        {
            case 1:
                result = buildVectorEasy(lastSpawned);
                break;
            case 2:
                result = buildVectorMed(lastSpawned);
                break;
            case 3:
                result = buildVectorHard(lastSpawned);
                break;
            case 4:
                result = buildVectorInsane(lastSpawned);
                break;
            default:
                result = buildVectorEasy(lastSpawned);
                break;
        }

        memo.Add (result);
        return result;
    }

    public int CalculateNoOfPieces()
    {
        return difficulty * 100;
    }

    private float CalculateMovement()
    {
        switch (difficulty)
        {
            case 1:
                return 0.1f;
            case 2:
                return 0.14f;
            case 3:
                return 0.15f;
            case 4:
                return 0.16f;
            default:
                return 0.1f;
        }
    }

    public void CountCollision()
    {
        collisions += 1;

        if (CalculateNoOfPieces() == collisions)
        {
            Debug.Log("Level Complete");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =
            new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z - CalculateMovement());
    }
}
