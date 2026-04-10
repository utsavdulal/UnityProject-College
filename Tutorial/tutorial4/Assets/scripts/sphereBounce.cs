using UnityEngine;

public class SphereBounce : MonoBehaviour
{
    public float bounceForce = 10f; // Amount of force applied for the bounce
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the sphere
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an upward force to the sphere
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}