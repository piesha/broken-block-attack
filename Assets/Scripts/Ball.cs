using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config parameters
    [SerializeField] paddle paddle1 = default;
    [SerializeField] float xPush = 5f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds = default;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted=false;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D ballRigidBody;




    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        ballRigidBody.simulated = false;    //suggested by Nina to rigid body movement of the ball with paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        





    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
            
        }


        

    }
    
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballRigidBody.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
            ballRigidBody.simulated = true;   //suggested by Nina to rigid body movement of the ball with paddle

        }

    }
    private void LockBallToPaddle()
    {
        
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; ;
            myAudioSource.PlayOneShot(clip);
            

        }
    }




}
