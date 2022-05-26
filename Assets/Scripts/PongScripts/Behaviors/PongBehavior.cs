using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehavior : AgentBehaviour
{
    public float accelAdjust = 2.0f;
    private Vector3 direction;
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
        //TODO: ajouter le moveonice 
    }
    //Called at each frame of the game
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = direction * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, (agent.maxAccel + accelAdjust)));
        return steering;
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contactPoint = collision.contacts[0];
        direction = Vector3.Reflect(direction, contactPoint.normal);
    }

    public void crazyBall(){

    }
}
