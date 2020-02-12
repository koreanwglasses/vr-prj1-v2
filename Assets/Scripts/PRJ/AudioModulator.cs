using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioModulator : MonoBehaviour
{
    public GameObject control;
    public float influence = 0.1f;
    public float maxVolume = 1;

    private AudioSource audioSource;
    private MovementEstimator movementEstimator;
    private GlobalControls globalControls;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        movementEstimator = control.GetComponent<MovementEstimator>();
        globalControls = this.gameObject.GetComponentInParent<GlobalControls>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = movementEstimator.linearVelocity;
        if (globalControls) v *= globalControls.sensitivity;
        audioSource.volume = Mathf.Min(influence * v.sqrMagnitude, maxVolume);
    }
}
