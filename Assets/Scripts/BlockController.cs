using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int ScoreValue = 1;

    public int RageValue = 1;

    public GameObject hitSoundFab;

    private AudioSource hitSound;

    public GameObject missSoundFab;

    private AudioSource missSound;

    private LevelController levelControl;

    private int particleCollisions;

    public int particleCollisionThreshold = 6;

    void Start()
    {
        levelControl = transform.parent.GetComponent<LevelController>();

        if (hitSoundFab != null)
        {
            GameObject _hitSoundFab = Instantiate(hitSoundFab);
            hitSound = _hitSoundFab.GetComponent<AudioSource>();
        }

        if (missSoundFab != null)
        {
            GameObject _missSoundFab = Instantiate(missSoundFab);
            missSound = _missSoundFab.GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.layer.ToString());
        Debug.Log(collision.gameObject.layer.ToString());
        if (collision.gameObject.layer == 3 && gameObject.layer != 9)
        {
            OnHit();
        }

        if (collision.gameObject.layer == 7 && gameObject.layer != 9)
        {
            OnMiss();
        }

        if (collision.gameObject.layer == 7 && gameObject.layer == 9){
            levelControl.EndLevel();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        particleCollisions++;
        if (particleCollisions >= particleCollisionThreshold)
        {
            OnHit();
        }
    }

    void OnMiss()
    {
        if (missSound)
        {
            missSound.Play();
        }
        levelControl.Miss (ScoreValue, RageValue);
        Destroy (gameObject);
    }

    void OnHit()
    {
        if (hitSound)
        {
            hitSound.Play();
        }
        levelControl.Hit (ScoreValue, RageValue);
        Destroy (gameObject);
    }
}
