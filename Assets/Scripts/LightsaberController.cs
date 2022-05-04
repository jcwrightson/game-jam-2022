using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightsaberController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference actionRefLH;

     [SerializeField]
    private InputActionReference actionRefRH;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    AudioSource audioData;

    void Start()
    {
        actionRefLH.action.performed += OnTrigger;
        actionRefRH.action.performed += OnTrigger;

        audioData = GetComponent<AudioSource>();
        if(system.isEmitting){
			audioData.Play(0);
        }
        
    }


    private void OnTrigger(InputAction.CallbackContext obj){
        if(system.isEmitting){
            system.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            audioData.Stop();
            return;
        }
        system.Play(true);
        audioData.Play(0);

    }

}
