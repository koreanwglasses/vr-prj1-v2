using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearController : MonoBehaviour
{
    [Header("References")]
    public GameObject control;

    [Header("Parameters")]
    public Vector3 baseScale = new Vector3(0, 0, 0);
    public Vector3 scaleInfluence = new Vector3(1,1,1);

    private MovementEstimator movementEstimator;

    // Start is called before the first frame update
    void Start()
    {
        movementEstimator = control.GetComponent<MovementEstimator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = movementEstimator.linearVelocity;
        //Vector3 v2 = Vector3.Scale(movementEstimator.linearVelocity, movementEstimator.linearVelocity);

        this.gameObject.transform.LookAt(this.gameObject.transform.position + v);
        this.gameObject.transform.localScale = baseScale + v.sqrMagnitude * scaleInfluence;
    }
}
