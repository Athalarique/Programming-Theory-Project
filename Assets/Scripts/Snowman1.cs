using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Snowman1 : Snowman // INHERITANCE
{
    public SphereCollider playerSc;
    private bool isRotating = false;
    private bool isRot = false;
    private bool chceckingForStop = false;
    private float actualTotalRotation = 0;
    private float nextAngleX = 0;
    private float chceckingAngle = 45;
    [SerializeField] private float targetAngle = 180f;
    [SerializeField] private float rotationSpeedPerSecond = 1f;
    private float timeCount = 0;
    private float rotationTime = 1.0f;
    private float degreesPerSecond;
    private Vector3 currentEulerAngles;
    private float x;
    private float y;
    private float z;
    private Vector3 startingPosition;
    protected override void Update()
    {
        //playerSc.enabled = false;

        //if (isRotating)
        //{
        //    StartCoroutine(Jump());
        //}

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isRotating)
        {
            StartCoroutine(Jump());
        }
    }
    // POLYMORPHISM
    //public override void jump()
    //{
    //    //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    playerRb.useGravity = false;
    //    playerSc.enabled = false;
    //    //Quaternion rotateJump = Quaternion.AngleAxis(180, Vector3.right);
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, rotateJump, 0.05f);

    //    isRotating = true;
    //    isOnGround = false;

    //}

    IEnumerator Jump() // POLYMORPHISM
    {
        isRotating = true;
        playerRb.useGravity = false;
        startingPosition = transform.position;
        
        float waitTime = 0.0001f;

        for (int i = 0; i <= 180; i++)
        {
            transform.Rotate(-2, 0, 0); // Equivalently, transform.Rotate(Vector3.right, 1);
            //transform.Rotate(pitchSpeed * Time.deltaTime, 0 , 0);

            yield return wait(waitTime);
        }

        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = startingPosition;
        playerRb.useGravity = true;
        playerSc.enabled = true;
        isRotating = false;
    }

    IEnumerator wait(float waitTime)
    {
        float counter = 0f;

        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            
            yield return null;
        }
    }
}
