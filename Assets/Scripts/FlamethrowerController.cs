using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlamethrowerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference actionRef;

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

    // AudioSource audioData;
    void Start()
    {
        actionRef.action.performed += OnTrigger;

        // audioData = GetComponent<AudioSource>();
        if (system.isEmitting)
        {
            // audioData.Play(0);
        }
    }

    void OnDestroy()
    {
        actionRef = null;
    }

    private void OnTrigger(InputAction.CallbackContext context)
    {
        if (actionRef != null)
        {
            float TriggerValue = context.ReadValue<float>();

            if (TriggerValue > 0.8f && TriggerValue <= 1f)
            {
                system.Play(true);
            }
            else
            {
                system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}
