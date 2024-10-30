using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class PhantomCreation : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject originalBall;
    public Rigidbody ballBody;



    public GameObject originalLineVector;
    public GameObject originalVector;

    public GameObject originalLineVectorX;
    public GameObject originalVectorX;

    public GameObject originalLineVectorY;
    public GameObject originalVectorY;

    public GameObject originalLineVectorZ;
    public GameObject originalVectorZ;



    public Rigidbody vectorBody;
    public Rigidbody vectorBodyX;
    public Rigidbody vectorBodyY;
    public Rigidbody vectorBodyZ;

    public Transform vectorShape;
    public Transform vectorShapeX;
    public Transform vectorShapeY;
    public Transform vectorShapeZ;

    public GameObject phantomBall;
    public GameObject phantomLineVector;
    public GameObject phantomHeadVector;
    int countFrame;
    void Awake()
    {

        Debug.Log("Entered awakePC");
        countFrame =0;
        ballBody = originalBall.GetComponent<Rigidbody>();
        vectorBody = originalVector.GetComponent<Rigidbody>();
        vectorBodyX = originalVectorX.GetComponent<Rigidbody>();
        vectorBodyY = originalVectorY.GetComponent<Rigidbody>();
        vectorBodyZ = originalVectorZ.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        vectorShape = originalLineVector.GetComponent<Transform>();
        vectorShapeX = originalLineVectorX.GetComponent<Transform>();
        vectorShapeY = originalLineVectorY.GetComponent<Transform>();
        vectorShapeZ = originalLineVectorZ.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        countFrame++;
        Debug.Log("Current frame is " + countFrame);
        //It is updated every frame it is used to execut almost everything , before rendering a frame

        if (countFrame == 100)
        {

            Debug.Log("Entered the condition1");
            createPhantom();
        }

        if (countFrame == 360)
        {

            Debug.Log("Entered the condition2");
            createPhantom();
        }

        if (countFrame == 610)
        {

            Debug.Log("Entered the condition3");
            createPhantom();
        }

        
    }

    public void createPhantom()
    {
        //  Debug.Log("Phantom position x " + vectorBody.position.x + " position y " + vectorBody.position.y);
        // Vector3 currentPosition = new Vector3(rb.position.x, rb.position.y, rb.position.z);
        GameObject _PhantomBall = Instantiate(phantomBall, ballBody.position, ballBody.rotation);

        float ballVectorG =sqrt(ballBody.velocity.x * ballBody.velocity.x + ballBody.velocity.y * ballBody.velocity.y + ballBody.velocity.z * ballBody.velocity.z);


        GameObject _PhantomLineVector = Instantiate(phantomLineVector, vectorBody.position, vectorBody.rotation);
        GameObject _PhantomHeadVector = Instantiate(phantomHeadVector, vectorBody.position, vectorBody.rotation);
        _PhantomLineVector.transform.localScale = vectorShape.localScale;

        if (ballBody.velocity.x != 0 && abs(ballBody.velocity.x) != ballVectorG) { 
        GameObject _PhantomLineVectorX = Instantiate(phantomLineVector, vectorBodyX.position, vectorBodyX.rotation);
        GameObject _PhantomHeadVectorX = Instantiate(phantomHeadVector, vectorBodyX.position, vectorBodyX.rotation);
        _PhantomLineVectorX.transform.localScale = vectorShapeX.localScale;
    }

        if (ballBody.velocity.y != 0 && abs(ballBody.velocity.y) != ballVectorG)
        {
            GameObject _PhantomLineVectorY = Instantiate(phantomLineVector, vectorBodyY.position, vectorBodyY.rotation);
            GameObject _PhantomHeadVectorY = Instantiate(phantomHeadVector, vectorBodyY.position, vectorBodyY.rotation);
            _PhantomLineVectorY.transform.localScale = vectorShapeY.localScale;
        }
        if (ballBody.velocity.z != 0 && abs(ballBody.velocity.z) != ballVectorG)
        {
            GameObject _PhantomLineVectorZ = Instantiate(phantomLineVector, vectorBodyZ.position, vectorBodyZ.rotation);
            GameObject _PhantomHeadVectorZ = Instantiate(phantomHeadVector, vectorBodyZ.position, vectorBodyZ.rotation);
            _PhantomLineVectorZ.transform.localScale = vectorShapeZ.localScale;
        }
    }
}
