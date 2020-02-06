using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Control")]
    public GameObject control;

    private MovementEstimator movementEstimator;

    // Start is called before the first frame update
    void Start()
    {
        movementEstimator = control.GetComponent<MovementEstimator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v2 = Vector3.Scale(movementEstimator.linearVelocity, movementEstimator.linearVelocity);
        this.gameObject.transform.localScale = new Vector3(1, 1, 1) + 0.1f * v2;
    }
}
