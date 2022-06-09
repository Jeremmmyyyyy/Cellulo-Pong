using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKeyboard : AgentBehaviour
{
    private GameManager gameManager;
    float horizontal;
    float vertical;
    public Powers powers;
    Steering steering = new Steering();
    bool collisionBehavior;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        powers = GameObject.Find("Powers").GetComponent<Powers>();
        gameManager.setPlayer1IsArrowTo(false);
        agent.ClearHapticFeedback();
    }

    public override void OnCelluloLongTouch(int key)
    {
        base.OnCelluloLongTouch(key);
        if (agent.tag == "P1")
        {
            if (key == 0 || key == 2 || key == 4)
            {
                powers.buttonsRealCellulo(key, "P1");
            }

        }
        else if (agent.tag == "P2")
        {

            if (key == 0 || key == 2 || key == 4)
            {
                powers.buttonsRealCellulo(key, "P2");
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        agent.ActivateDirectionalHapticFeedback();
        foreach (ContactPoint contact in collision.contacts)
        steering.linear = collision.contacts[0].normal.normalized*agent.maxAccel;
        collisionBehavior = true;  
        Invoke("setFalse", 0.1f);   
    }

    private void setFalse(){
        collisionBehavior = false; 
    }
    void OnCollisionExit(Collision collision){
        agent.DeActivateDirectionalHapticFeedback();
        collisionBehavior = false; 
    }

    public override Steering GetSteering()
    {

        //ne peut bouger que si la partie a commencer
        if (gameManager.game_as_start())
        {
            if(!collisionBehavior){
                if (gameManager.getPlayerCommand(gameObject.tag) == "wasd"){
                    horizontal = Input.GetAxis("Horizontal2");
                    vertical = Input.GetAxis("Vertical2");
                }
                else{
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
            }
        }


        steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }
}