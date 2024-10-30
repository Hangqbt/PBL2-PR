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
        //This method helps initialize every variable
        rb = GetComponent<Rigidbody>();
        Debug.Log("The program started");
        
    }

    private void Start()
    {
        countFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {

        countFrame++;
    }

    private void FixedUpdate()
    {
        //It is used before any physics calculations
        //Vector3 movementV = new Vector3(ballMovementVectorX, ballMovementVectorY, ballMovementVectorZ);
        //rb.AddForce(movementV * speed);

        

        if (countFrame>=frameLimit) {
            Debug.Log("Entered the condition2");
            rb.Sleep();
        }
       
    }

   
}
