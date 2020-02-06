using UnityEngine;

// Estimate the motion of an object and access it from other scripts
public class MovementEstimator : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Number of samples to use in computing player movement")]
    public int numSamples = 30;

    private float[] timeSamples;
    private Vector3[] positionSamples;
    private Quaternion[] rotationSamples;

    public Vector3 linearVelocity { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize sample arrays
        timeSamples = new float[numSamples];
        positionSamples = new Vector3[numSamples];
        rotationSamples = new Quaternion[numSamples];

        for(int i = 0; i < numSamples; i++)
        {
            timeSamples[i] = i/60f;
            positionSamples[i] = this.gameObject.transform.position;
            rotationSamples[i] = this.gameObject.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Shift entries in history to the left
        for(int i = 0; i < numSamples - 1; i++)
        {
            timeSamples[i] = timeSamples[i + 1];
            positionSamples[i] = positionSamples[i + 1];
            rotationSamples[i] = rotationSamples[i + 1];
        }

        // Record current transform
        timeSamples[numSamples - 1] = Time.time;
        positionSamples[numSamples - 1] = this.gameObject.transform.position;
        rotationSamples[numSamples - 1] = this.gameObject.transform.rotation;

        // Estimate linear and angular velocity
        MathUtils.OLS(timeSamples, positionSamples, out Vector3 linearVelocity_, out _);
        linearVelocity = linearVelocity_;
    }
}
