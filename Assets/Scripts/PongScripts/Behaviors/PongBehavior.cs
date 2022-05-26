using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehavior : AgentBehaviour
{
    public float accelAdjust = 2.0f;
    private Vector3 direction;
    private bool isWallCollided;
    private bool stopBall;
    //private Rigidbody rigidBody;
    // private GameObject leftWall;
    // private GameObject rightWall;
    // private GameObject ball;
    // Start is called before the first frame update
    private Vector3 startBallMovement(){
        float random = Random.Range(0, 2);
        if (random > 0){
            return new Vector3(-1, 0, 0); //move left
        }else{
            return new Vector3(1, 0, 0); //move right
        }
    }


    void Start()
    {
        direction = startBallMovement();
        // leftWall = GameObject.FindGameObjectsWithTag("LWall")[0];
        // rightWall = GameObject.FindGameObjectsWithTag("RWall")[0];
        // ball = GameObject.FindGameObjectsWithTag("Ball")[0];

        //Physics.IgnoreCollision(leftWall.GetComponent<Collider>(), ball.GetComponent<Collider>());
        //Physics.IgnoreCollision(rightWall.GetComponent<Collider>(), ball.GetComponent<Collider>());
        //TODO: ajouter le moveonice 
    }
    void Update()
    {
    }
    //Called at each frame of the game
    public override Steering GetSteering()
    {
        Steering steering = new Steering();

        if(stopBall){
            steering.linear = new Vector3(0, 0, 0);
        }else{
            steering.linear = direction * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, (agent.maxAccel + accelAdjust)));
        }
        return steering;
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contactPoint = collision.contacts[0];
        direction = Vector3.Reflect(direction, contactPoint.normal);
    }

    // private void OnTriggerEnter(Collider other) {
    //     if (other.tag == "LWall" || other.tag == "RWall")
    //     {
    //         Debug.Log("tada colide");
    //         Physics.IgnoreCollision(ball.GetComponent<Collider>(), leftWall.GetComponent<Collider>(), false);
    //         Physics.IgnoreCollision(ball.GetComponent<Collider>(), rightWall.GetComponent<Collider>(), false);
    //     }
    // }

    public void crazyBall(){
        stopBall = true;
        Invoke("setBoolFalse", 5.0f);
    }

    public void setBoolFalse(){
        stopBall = false;
    }
    
}
