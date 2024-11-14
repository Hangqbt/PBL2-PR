using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;



public class VectorComponentMovement : MonoBehaviour
{


    //Script reference
    BallMovement ballMovement;

    //This vector rigid body
    private Rigidbody vectorBody;

    private Transform vectorShape, vectorLineShape;
    public GameObject vectorLineGameObject, vectorGameObject;

    //Game object of the class ballMovement
    public GameObject ballGameObject;
    //Rigid body of the ball
    public Rigidbody ballBody;
    public SphereCollider ballColider;
    public Vector3 ballColliderSize;


    //Identifier to know wheter the component is X, Y or Z 
    //X=0 Y=1 Z=2
    public int componentId;

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
        float ballVectorX, ballVectorY, ballVectorZ, ballVector, ballVectorG, reScale, vectorAngle;

        ballVectorX = ballBody.velocity.x;
        ballVectorY = ballBody.velocity.y;
        ballVectorZ = ballBody.velocity.z;
        ballVector=0;
        reScale = 0;
        vectorAngle = 0;

        ballVectorG = sqrt(ballVectorX * ballVectorX + ballVectorY * ballVectorY + ballVectorZ * ballVectorZ);

        switch (componentId) {
            case 0:
                ballVector = ballVectorX;
                reScale = (ballColliderSize.x - 0.5f + vectorLineShape.localScale.z * 5);
                break;
            case 1:
                ballVector = ballVectorY;
                reScale = (ballColliderSize.y - 0.5f + vectorLineShape.localScale.z * 5);
                break;
            case 2:
                ballVector = ballVectorZ;
                reScale = (ballColliderSize.z - 0.5f + vectorLineShape.localScale.z * 5);
                break;

        }
        

        if (abs(ballVector)== ballVectorG) {
            ballVector=0;
        }

        if (ballVector == 0)
        {
            vectorGameObject.SetActive(false);
        }
        else {
            vectorGameObject.SetActive(true);
        }

            vectorLineShape.localScale = new Vector3(0.1f, 0.1f, 0.1f * abs(ballVector));

        

        //Figure the new position of the vector depending on the width and angle of it
   
        

        //Double declaration for Z and Y depending whether there is a velocity in x or not

        reScale = abs(reScale);
  

        //Changing the values in case the velocity vectors are negative
        if (ballVector < 0)
        {
            reScale = -reScale;
            vectorAngle += 180;
        }




        switch (componentId)
        {
            case 0:
                vectorBody.MovePosition(new Vector3(
                    ballBody.position.x + reScale,
                    ballBody.position.y,
                    ballBody.position.z)); 

                vectorShape.localEulerAngles = new Vector3(vectorAngle, 270, 0);
                break;
            case 1:
                vectorBody.MovePosition(new Vector3(
                ballBody.position.x,
                ballBody.position.y + reScale,
                ballBody.position.z)); ;

                vectorShape.localEulerAngles = new Vector3(vectorAngle+90, 270, 0);
                break;
            case 2:
                vectorBody.MovePosition(new Vector3(
                ballBody.position.x,
                ballBody.position.y,
                ballBody.position.z + reScale));

                vectorShape.localEulerAngles = new Vector3(0, 270- vectorAngle-90, 0);
                break;

        }

       



        //Rotation x afect plane XY, rotation Y affect plane XZ



        Debug.Log("\nRotation x " + vectorShape.localEulerAngles.x + "  Rotation y " + vectorShape.localEulerAngles.y + "  Rotation z " + vectorShape.localEulerAngles.z);
        Debug.Log("The x size is: " + vectorShape.localScale.z);

    }



}

