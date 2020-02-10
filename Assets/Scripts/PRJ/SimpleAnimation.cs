using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
    public Vector3 angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion localRotation = this.gameObject.transform.rotation;
        localRotation.ToAngleAxis(out float angle, out Vector3 axis);
        Vector3 newRotation = axis * angle + angularVelocity * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.AngleAxis(newRotation.magnitude, newRotation.normalized);
    }
}
