using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNavigation : MonoBehaviour
{

    public float threshold = 0.1f;
    public float acceleration = 1f;
    public float maxSpeed = 10f;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(h, 0, v);

        if(moveVector.magnitude > threshold)
        {
            velocity += (moveVector * acceleration) * Time.deltaTime;
        } else
        {
            Vector3 newVelocity = velocity + (-velocity * acceleration) * Time.deltaTime;
            if(Vector3.Dot(velocity, newVelocity) < 0)
            {
                velocity = new Vector3(0, 0, 0);
            } else
            {
                velocity = newVelocity;
            }
        }
        if(velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        this.gameObject.transform.position += velocity * Time.deltaTime;
    }
}
