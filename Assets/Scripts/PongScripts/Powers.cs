using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powers : MonoBehaviour
{
    public CelluloAgent PaddlePlayer1;
    public CelluloAgent PaddlePlayer2;
    public CelluloAgent Ball;
    public GameManager gameManager;
    public PongBehavior pongBehavior;
    private List<string> ListPower1;
    private List<string> ListPower2;
    private bool status;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pongBehavior = GameObject.Find("PongBehavior").GetComponent<PongBehavior>();
        status = false;
    }

    private void Update() {
        if(gameManager.game_as_start() != status){
            powerColors();
            status = !status;
        }
    }

    public void handlePower(string buttonName){
        ListPower1 = gameManager.getPower1();
        ListPower2 = gameManager.getPower2();

        string[] player_power = buttonName.Split(':');
        int power = Int32.Parse(player_power[1]);
        power -= 1;
        
        string selectedPower;
        if(player_power[0] == "P1"){
            selectedPower = ListPower1[power];
            powerSwitch(selectedPower, player_power[0]);

        }else if(player_power[0] == "P2"){
            selectedPower = ListPower2[power];
            powerSwitch(selectedPower, player_power[0]);

        }
    }

    private void powerSwitch(string selectedPower, string playerThatUsedThePower){
        switch (selectedPower){
            case "CRAZYBALL":
                crazyBall();
                break;
            case "ZONEENLARGER":
                zoneEnlarger();
                break;
            case "ZONESHRINKER":
                zoneShrinker();
                break;
            case "FREEZEOPPONENT":
                if (playerThatUsedThePower == "P1"){
                    freezeOponent(PaddlePlayer2);
                }else if(playerThatUsedThePower == "P2"){
                    freezeOponent(PaddlePlayer1);
                }
                break;
            case "SLIMEOPPONENT":
                if (playerThatUsedThePower == "P1"){
                    slimeOponent(PaddlePlayer2);
                }else if(playerThatUsedThePower == "P2"){
                    slimeOponent(PaddlePlayer1);
                }                
                break;
            default:
                Debug.Log("Problem with power choose");
                break;
        }
    }

    private void crazyBall(){
        Debug.Log("crazy ball");
        pongBehavior.crazyBall();
    }

    private void zoneEnlarger(){
        Debug.Log("zone enlarger");
    }
    private void zoneShrinker(){
        Debug.Log("zone shrinker");
    }
    private void freezeOponent(CelluloAgent playerToFreeze){
        Debug.Log("freeze oponent");
    }
    private void slimeOponent(CelluloAgent playerToSlime){
        Debug.Log("slime oponent");
        playerToSlime.MoveOnMud();
        Invoke("clearHapticFeedback", 10);
    }


    public void clearHapticFeedback(CelluloAgent cellulo){
        cellulo.ClearHapticFeedback();
    }

    public void powerColors(){
       // PaddlePlayer1.
    }
}
