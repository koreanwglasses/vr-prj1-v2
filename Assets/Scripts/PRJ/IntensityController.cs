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


    // Start is called before the first frame update
    void Start()
    {
        this.lightComponent = this.gameObject.GetComponent<Light>();
        this.baseIntensity = this.lightComponent.intensity;
        movementEstimator = control.GetComponent<MovementEstimator>();    
    }

    // Update is called once per frame
    void Update()
    {
        float v2 = movementEstimator.linearVelocity.sqrMagnitude;
        lightComponent.intensity = baseIntensity + intensityInfluence * v2;
        
        if(gradientScale > 0)
        {
            lightComponent.color = gradient.Evaluate(v2 * gradientScale);
        }
    }
}
