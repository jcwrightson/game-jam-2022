using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<GameObject> Targets;

    public GameObject LevelEndFab;

    private List<Vector3> PositionMemo;

    private PlayerProgress progress;

    private int PerfectScore;

    private bool LevelComplete = true;


    void Start()
    {
        ResetLevel();
    }

    private void ResetLevel()
    {
        PerfectScore = 0;
        PositionMemo = new List<Vector3>();
        PlayerProgress.ResetProgress(0, 50); //Reset the Score back to 0 and rage back to 50
        transform.position = new Vector3(0, 0.5f, 20f); // Reset level position
        BuildLevel(PlayerProgress.Difficulty);
        LevelComplete = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!LevelComplete)
        {
            transform.position =
                new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z - CalculateMovement());
        }
    }

    private void BuildLevel(int dif)
    {
        for (var i = 0; i < CalculateNoOfPieces(); i++)
        {
            // Pick a random object to spawn
            int idx = UnityEngine.Random.Range(0, Targets.Count);

            Vector3 pos = buildPosition(i, dif);

            GameObject Target =
                Instantiate(Targets[idx], pos, transform.rotation, transform);

            PerfectScore =
                PerfectScore +=
                    Target.GetComponent<BlockController>().ScoreValue;
        }

        Vector3 finalPos = buildPosition(CalculateNoOfPieces(), 0);
        Instantiate(LevelEndFab, finalPos, transform.rotation, transform);
    }

    private Vector3 buildVectorDebug(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-1f, 1f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 1f); // Vertical
        float z = UnityEngine.Random.Range(3f, 10f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorEasy(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-1.5f, 1.5f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 1.5f); // Vertical
        float z = UnityEngine.Random.Range(2f, 5f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorMed(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-2f, 2f); // Horizontal
        float y = UnityEngine.Random.Range(0f, 2f); // Vertical
        float z = UnityEngine.Random.Range(1f, 4f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorHard(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-2f, 2f); // Horizontal
        float y = UnityEngine.Random.Range(-1f, 3f); // Vertical
        float z = UnityEngine.Random.Range(1f, 3f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildVectorInsane(Vector3 lastSpawned)
    {
        float x = UnityEngine.Random.Range(-3f, 3f); // Horizontal
        float y = UnityEngine.Random.Range(-1f, 3f); // Vertical
        float z = UnityEngine.Random.Range(0f, 2f); // Depth
        return new Vector3(x, transform.position.y + y, lastSpawned.z + z);
    }

    private Vector3 buildPosition(int i, int difficulty)
    {
        Vector3 lastSpawned;
        Vector3 result;

        if (i > 0)
        {
            lastSpawned = PositionMemo[i - 1];
        }
        else
        {
            lastSpawned = transform.position;
        }

        switch (difficulty)
        {
            case 0:
                result = buildVectorDebug(lastSpawned);
                break;
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

        PositionMemo.Add (result);
        return result;
    }

    public int CalculateNoOfPieces()
    {
        if (PlayerProgress.Difficulty == 0)
        {
            return 10;
        }
        else
        {
            return PlayerProgress.Difficulty * 100;
        }
    }

    private float CalculateMovement()
    {
        switch (PlayerProgress.Difficulty)
        {
            case 0: // Debug
                return 0.05f;
            case 1:
                return 0.1f;
            case 2:
                return 0.12f;
            case 3:
                return 0.13f;
            case 4:
                return 0.14f;
            default:
                return 0.1f;
        }
    }

    public void Hit(int scoreValue, int rageValue)
    {
        PlayerProgress.DecRage (rageValue);
        PlayerProgress.IncScore (scoreValue);
        isGameOver();
    }

    public void Miss(int scoreValue, int rageValue)
    {
        PlayerProgress.IncRage(rageValue * 2);

        isGameOver();
    }

    private void isGameOver()
    {
        if (PlayerProgress.Rage > 100)
        {
            // Loss
            LevelComplete = true;
            SceneManager.LoadScene(2); //load the fail screen
            return;
        }

        if (PlayerProgress.Score == PerfectScore)
        {
            // Perfect
            Debug.Log("Perfect Score!!");
            LevelComplete = true;
            SceneManager.LoadScene(3); //load the win screen
            return;
        }
    }

    public void EndLevel()
    {
        LevelComplete = true;
        SceneManager.LoadScene(3); //load the win screen
    }
}
