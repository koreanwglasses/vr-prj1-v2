using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;

    public bool followPosition;
    public bool followRotation;
    public bool followScale;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTransform();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTransform();
    }

    void UpdateTransform()
    {
        if (followPosition)
        {
            this.gameObject.transform.position = target.transform.position;
        }

        if (followRotation)
        {
            this.gameObject.transform.rotation = target.transform.rotation;
        }

        if (followScale)
        {
            this.gameObject.transform.localScale = target.transform.position;
        }
    }
}
