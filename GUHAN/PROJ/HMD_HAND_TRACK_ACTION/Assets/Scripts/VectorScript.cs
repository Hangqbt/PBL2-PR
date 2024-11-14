using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;



public class VectorScript : MonoBehaviour
{

    
    //Script reference
    BallMovement ballMovement;

    //This vector rigid body
    private Rigidbody vectorBody;
    private Transform vectorShape, vectorLineShape;
    public GameObject vectorLineGameObject;

    //Game object of the class ballMovement
    public GameObject ballGameObject;
    //Rigid body of the ball
    public Rigidbody ballBody;
    public SphereCollider ballColider;
    public Vector3 ballColliderSize;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Entered awakeVS");
        //Method that gets called before start that is useful to initizalize variables with information of other scripts

        ballBody = ballGameObject.GetComponent<Rigidbody>();
        ballColider = ballGameObject.GetComponent<SphereCollider>();

        ballColliderSize = ballColider.GetComponent<Collider>().bounds.size;
        
    }

    private void Start()
    {
        vectorBody = GetComponent<Rigidbody>();
        vectorShape = GetComponent<Transform>();
        vectorLineShape = vectorLineGameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float ballVectorX, ballVectorY, ballVectorZ, ballVectorG, verticalAnglexy, verticalAnglezy, horizontalAngle;

        ballVectorX = ballBody.velocity.x;
        ballVectorY = ballBody.velocity.y;
        ballVectorZ = ballBody.velocity.z;

        ballVectorG = sqrt(ballVectorX * ballVectorX + ballVectorY * ballVectorY + ballVectorZ * ballVectorZ);

        if (ballVectorX == 0 && ballVectorY == 0) {
            verticalAnglexy = 0; }
        else {
            verticalAnglexy = abs(ballVectorX / (sqrt(ballVectorX * ballVectorX + ballVectorY * ballVectorY)));
            verticalAnglexy = acos(verticalAnglexy); }


        if (ballVectorX == 0 && ballVectorZ == 0)
        {
            horizontalAngle = 0;
        }
        else
        {
            horizontalAngle = abs(ballVectorX / (sqrt(ballVectorX * ballVectorX + ballVectorZ * ballVectorZ)));
            horizontalAngle = acos(horizontalAngle);
        }


        if (ballVectorY == 0 && ballVectorZ == 0)
        {
            verticalAnglezy = 0;
        }
        else
        {
            verticalAnglezy = abs(ballVectorZ / (sqrt(ballVectorY * ballVectorY + ballVectorZ * ballVectorZ)));
            verticalAnglezy = acos(verticalAnglezy);
        }

      
        vectorLineShape.localScale = new Vector3(0.1f, 0.1f, 0.1f * ballVectorG);

        float reScaleX, reScaleY, reScaleZ;

        //Figure the new position of the vector depending on the width and angle of it
        reScaleX = (cos(horizontalAngle)) * (cos(verticalAnglexy)) * (ballColliderSize.x - 0.05f + vectorLineShape.localScale.z );


       // reScaleX = (cos(horizontalAngle)) * (cos(verticalAnglexy)) * (ballColliderSize.x - 0.5f + vectorLineShape.localScale.z * 5); original logic for the ball size 1


        //Double declaration for Z and Y depending whether there is a velocity in x or not
        if ((ballVectorX) == 0)
        {
            reScaleZ = (sin(horizontalAngle)) * (cos(verticalAnglezy)) * (ballColliderSize.z - 0.05f + vectorLineShape.localScale.z );
            reScaleY = sin(verticalAnglezy) * (ballColliderSize.y - 0.05f + vectorLineShape.localScale.z);
        }
        else
        {
            reScaleZ = (sin(horizontalAngle)) * (cos(verticalAnglexy)) * (ballColliderSize.z - 0.05f + vectorLineShape.localScale.z );
            reScaleY = sin(verticalAnglexy) * (ballColliderSize.y - 0.05f + vectorLineShape.localScale.z );
        }

        horizontalAngle = horizontalAngle * Mathf.Rad2Deg;
        verticalAnglezy = verticalAnglezy * Mathf.Rad2Deg;
        verticalAnglexy = verticalAnglexy * Mathf.Rad2Deg;

        


        reScaleX = abs(reScaleX);
        reScaleY = abs(reScaleY);
        reScaleZ = abs(reScaleZ);

        //Changing the values in case the velocity vectors are negative
        if (ballVectorX < 0)
        {
            reScaleX = -reScaleX;
            horizontalAngle = 180f - horizontalAngle;
            
       
        }
        if (ballVectorY < 0) {
            reScaleY = -reScaleY;

            if (ballVectorX == 0)
            {

                if (!(ballVectorX < 0 && ballVectorZ < 0))
                {

                    verticalAnglezy = 360f - verticalAnglezy;
                }
            }
            else
                //if (!(ballVectorX < 0 && ballVectorZ < 0))
            {
                
                verticalAnglexy = 360f - verticalAnglexy;
            }
        }
        if (ballVectorZ < 0)
        {
            reScaleZ = -reScaleZ;
            horizontalAngle = 360f - horizontalAngle;
            

        }
            vectorBody.MovePosition(new Vector3(
                ballBody.position.x + reScaleX,
                ballBody.position.y + reScaleY,
                ballBody.position.z + reScaleZ));


        Debug.Log("\nvertical Angle X-Y " + verticalAnglexy + "  vertical Angle Z-Y " + verticalAnglezy + "  horizontal Angle " +
            "" + horizontalAngle + "\nvelocity on x " + ballVectorX + "  velocity on y " + ballVectorY + "  velocity on z " + ballVectorZ);
        // Debug.Log("position x " + vectorBody.position.x+" position y " + vectorBody.position.y);


        //Rotation x afect plane XY, rotation Y affect plane XZ
        if ((ballVectorX) == 0)
            vectorShape.localEulerAngles = new Vector3(verticalAnglezy , 270 - horizontalAngle, 0);
        else
            vectorShape.localEulerAngles = new Vector3(verticalAnglexy , 270 - horizontalAngle , 0);

        Debug.Log("\nRotation x " + vectorShape.localEulerAngles.x + "  Rotation y " + vectorShape.localEulerAngles.y+ "  Rotation z " + vectorShape.localEulerAngles.z);
        Debug.Log("The x size is: " + vectorShape.localScale.z);

    }

      

    }

