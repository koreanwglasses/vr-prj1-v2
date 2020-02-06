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

    // Different behavior of scaling for negative/non-negative z 
    private float DualScAdd(float x, float y, float z)
    {
        if (z >= 0) return x + y * z;
        return x * Mathf.Exp(y*z);
    }

    private Vector3 DualScAddV(Vector3 x, float y, Vector3 z)
    {
        float res_x = DualScAdd(x.x, y, z.x);
        float res_y = DualScAdd(x.y, y, z.y);
        float res_z = DualScAdd(x.z, y, z.z);
        return new Vector3(res_x, res_y, res_z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = movementEstimator.linearVelocity;

        this.gameObject.transform.LookAt(this.gameObject.transform.position + v);
        this.gameObject.transform.localScale = DualScAddV(baseScale, v.sqrMagnitude, scaleInfluence);
    }
}
