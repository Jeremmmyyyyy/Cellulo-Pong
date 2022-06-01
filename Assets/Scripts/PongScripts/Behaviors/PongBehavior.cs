using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehavior : AgentBehaviour
{
    public float accelAdjust = 2.0f;
    private Vector3 direction;
    private bool isWallCollided;
    static bool changeBallDirection;
    public GameManager gameManager;

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
        agent.MoveOnIce();
    }
    void Update()
    {
    }
    //Called at each frame of the game
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        if(gameManager.game_as_start()){
            
            if(changeBallDirection){
                Debug.Log(changeBallDirection);
                Vector3 newDir = randomOpposedDirection(direction);
                direction = newDir;
                changeBallDirection = false;
            }else{
                steering.linear = direction * agent.maxAccel;
                steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, (agent.maxAccel + accelAdjust)));
            }
        
        }
        return steering;
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contactPoint = collision.contacts[0];
        direction = Vector3.Reflect(direction, contactPoint.normal);
    }

    public void crazyBall(){
        changeBallDirection = true;
    }

    public Vector3 randomOpposedDirection(Vector3 vect){
        float random = Random.Range(-100, 100);
        float z = random / 100.0f;
        return new Vector3(-vect.x, 0, z);
    }

}
