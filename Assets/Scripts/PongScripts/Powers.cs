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
    public ZoneSwitcher zoneSwitcher;
    private List<string> ListPower1;
    private List<string> ListPower2;
    private bool status;

    private Dictionary<string, Color> colorPowerList;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pongBehavior = GameObject.Find("PongBehavior").GetComponent<PongBehavior>();
        zoneSwitcher = GameObject.Find("ZoneSwitcher").GetComponent<ZoneSwitcher>();
        status = false;

        colorPowerList = new Dictionary<string, Color>();
        colorPowerList.Add("CRAZYBALL", Color.magenta);
        colorPowerList.Add("ZONEENLARGER", Color.red);
        colorPowerList.Add("ZONESHRINKER", Color.blue);
        colorPowerList.Add("FREEZEOPPONENT", Color.cyan);
        colorPowerList.Add("SLIMEOPPONENT", Color.green);
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
        zoneSwitcher.zoneEnlarger();
    }
    private void zoneShrinker(){
        Debug.Log("zone shrinker");
        zoneSwitcher.zoneShrinker();
    }
    private void freezeOponent(CelluloAgent playerToFreeze){
        Debug.Log("freeze oponent");
        playerToFreeze.SetHapticBackdriveAssist(-1, -1, -1);
        Invoke("clearHapticFeedback", 5);
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
        //reset the color of the cellulos after the game has started and the players have found their cellulo
        PaddlePlayer1.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.black, 0);
        PaddlePlayer2.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.black, 0);
        ListPower1 = gameManager.getPower1();
        ListPower2 = gameManager.getPower2();

        //assign the leds to the power
        int j = 0;
        for(int i = 0; i < ListPower1.Count; ++i){
            assignLedToPower(PaddlePlayer1, ListPower1[i], j);
            j += 2;
        }
        j=0;
        for(int i = 0; i < ListPower2.Count; ++i){
            assignLedToPower(PaddlePlayer2, ListPower2[i], j);
            j += 2;
        }
    }

    public void assignLedToPower(CelluloAgent agent, string power, int LED){
        switch (power){
            case "CRAZYBALL":
                agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, colorPowerList[power], LED);
                break;
            case "ZONEENLARGER":
                agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, colorPowerList[power], LED);
                break;
            case "ZONESHRINKER":
                agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, colorPowerList[power], LED);
                break;
            case "FREEZEOPPONENT":
                agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, colorPowerList[power], LED);
                break;
            case "SLIMEOPPONENT":
                agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, colorPowerList[power], LED);
                break;
            default:
                Debug.Log("Not able to add correct color to power");
                break;
        }
    }
}
