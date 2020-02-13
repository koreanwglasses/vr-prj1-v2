using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInWandDirection : MonoBehaviour
{
	public Transform wandTransform;
	public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(hmove, 0, vmove);
		Quaternion wandRotation = wandTransform.localRotation;
		Matrix4x4 wandRotationMatrix = Matrix4x4.Rotate(wandRotation);
		moveVector = wandRotationMatrix.MultiplyVector(moveVector);


        transform.Translate(moveVector * Time.deltaTime * speed, Space.World);
    }
}
