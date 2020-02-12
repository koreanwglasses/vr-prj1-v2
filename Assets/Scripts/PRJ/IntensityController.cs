using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityController : MonoBehaviour
{

    public GameObject control;

    public float intensityInfluence;
    public float gradientScale;

    public Gradient gradient;

    private Light lightComponent;
    private float baseIntensity;
    private MovementEstimator movementEstimator;
    private GlobalControls globalControls = null;


    // Start is called before the first frame update
    void Start()
    {
        lightComponent = this.gameObject.GetComponent<Light>();
        baseIntensity = this.lightComponent.intensity;
        movementEstimator = control.GetComponent<MovementEstimator>();    
        globalControls = this.gameObject.GetComponentInParent<GlobalControls>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = movementEstimator.linearVelocity;
        if (globalControls) v *= globalControls.sensitivity;

        float v2 = v.sqrMagnitude;

        lightComponent.intensity = baseIntensity + intensityInfluence * v2;
        
        if(gradientScale > 0)
        {
            lightComponent.color = gradient.Evaluate(v2 * gradientScale);
        }
    }
}
