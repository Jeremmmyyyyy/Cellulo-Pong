using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys

public class MoveWithKeyboardBehavior : AgentBehaviour
{

    float horizontal;
    float vertical;
    private GameManager gameManager;

    static bool wasdLongPressed;
    static bool arrowsLongPressed;
    static bool previousGetBotIsGhost;
    public void Start()
    {   
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        wasdLongPressed = false;
        arrowsLongPressed = false;
        previousGetBotIsGhost = true;        
    }

    //Override of the same called method. Implement the start function if both player have a long press
    public override void OnCelluloLongTouch(int key)
    {
        base.OnCelluloLongTouch(key);
        if(gameManager.getPlayerCommand(gameObject.tag) == "wasd"){
            Debug.Log("Long press detected on wasd");
            wasdLongPressed = true;
        }else{
            arrowsLongPressed = true;
            Debug.Log("Long press detected on arrows");
        }        
    }
    //Method that changes between the two haptic behaviors in function of the Ghost/Sheep mode
    public void changeMovingBehavior(){
        bool botIsGhost = gameManager.getBotIsGhost();
        if (previousGetBotIsGhost != botIsGhost){
            if(botIsGhost){
                gameManager.changeMovingBehavior(botIsGhost);
                previousGetBotIsGhost = botIsGhost;
                Debug.Log("move on stone");
            }

            else{
                gameManager.changeMovingBehavior(botIsGhost);
                previousGetBotIsGhost = botIsGhost;
                Debug.Log("backdriveassist");
            }
        }
    }

    public override Steering GetSteering()
    {
        changeMovingBehavior();
        if (wasdLongPressed && arrowsLongPressed)
        {
            //gameManager.gameStatus(false);
        }
        //ne peut bouger que si la partie a commencer
        if (gameManager.game_as_start())
        {
            if (gameManager.getPlayerCommand(gameObject.tag)=="wasd")
            {
                horizontal = Input.GetAxis("Horizontal2");
                vertical = Input.GetAxis("Vertical2");
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
            }
        }

        Steering steering = new Steering();

        steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }

}