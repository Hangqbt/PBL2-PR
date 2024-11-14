using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    int countFrame;
    public int frameLimit;
    public GameObject phantomBall;
    public float ballMovementVectorX, ballMovementVectorY, ballMovementVectorZ;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize Rigidbody and enable gravity
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        Debug.Log("The program started");
    }

    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Add a movement force for testing bounce effect if desired
        Vector3 movementV = new Vector3(ballMovementVectorX, ballMovementVectorY, ballMovementVectorZ);
            rb.AddForce(movementV * speed);

        // Optional: Frame limit functionality for disabling the ball
        if (countFrame >= frameLimit)
        {
            Debug.Log("Frame limit reached.");
            rb.velocity = Vector3.zero;  // Stops movement without sleep
        }

        // Damping force applied against the current velocity
        rb.velocity *= 0.98f; // Adjust multiplier to control slowdown
        rb.angularVelocity *= 0.98f;
    }

}
