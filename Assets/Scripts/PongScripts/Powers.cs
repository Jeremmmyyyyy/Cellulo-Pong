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
    private CelluloAgent currentPlayer;
    private Dictionary<string, Color> colorPowerList;
    private Dictionary<string, string> tagToStringDic;


    private Color32 c1 = new Color32(255, 190, 11, 255);
    private Color32 c2 = new Color32(251, 86, 7, 255);
    private Color32 c3 = new Color32(255, 0, 110, 255);
    private Color32 c4 = new Color32(131, 56, 236, 255);
    private Color32 c5 = new Color32(58, 134, 255, 255);

    private string crazyBallText = "CRAZY BALL";
    private string zoneEnlargerText = "ZONE ENLARGER";
    private string zoneShrinkerText = "ZONE SHRINKER";
    private string freezeOpponentText = "FREEZE OPPONENT";
    private string slimeOpponentText = "SLIM OPPONENT";



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pongBehavior = GameObject.Find("PongBehavior").GetComponent<PongBehavior>();
        zoneSwitcher = GameObject.Find("ZoneSwitcher").GetComponent<ZoneSwitcher>();
        status = false;

        colorPowerList = new Dictionary<string, Color>();
        colorPowerList.Add("CRAZYBALL", c1);
        colorPowerList.Add("ZONEENLARGER", c2);
        colorPowerList.Add("ZONESHRINKER", c3);
        colorPowerList.Add("FREEZEOPPONENT", c4);
        colorPowerList.Add("SLIMEOPPONENT", c5);

        tagToStringDic = new Dictionary<string, string>();
        tagToStringDic.Add("CRAZYBALL", crazyBallText);
        tagToStringDic.Add("ZONEENLARGER", zoneEnlargerText);
        tagToStringDic.Add("ZONESHRINKER", zoneShrinkerText);
        tagToStringDic.Add("FREEZEOPPONENT", freezeOpponentText);
        tagToStringDic.Add("SLIMEOPPONENT", slimeOpponentText);


    }

    private void Update()
    {
        if (gameManager.game_as_start() != status)
        {
            powerColors();
            status = !status;
        }
    }

    public void handlePower(string buttonName)
    {
        ListPower1 = gameManager.getPower1();
        ListPower2 = gameManager.getPower2();

        string[] player_power = buttonName.Split(':');
        int power = Int32.Parse(player_power[1]);
        power -= 1;

        string selectedPower;
        if (player_power[0] == "P1")
        {
            selectedPower = ListPower1[power];
            powerSwitch(selectedPower, player_power[0]);

        }
        else if (player_power[0] == "P2")
        {
            selectedPower = ListPower2[power];
            powerSwitch(selectedPower, player_power[0]);

        }
    }

    private void powerSwitch(string selectedPower, string playerThatUsedThePower)
    {
        switch (selectedPower)
        {
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
                if (playerThatUsedThePower == "P1")
                {
                    freezeOponent(PaddlePlayer2);
                }
                else if (playerThatUsedThePower == "P2")
                {
                    freezeOponent(PaddlePlayer1);
                }
                break;
            case "SLIMEOPPONENT":
                if (playerThatUsedThePower == "P1")
                {
                    slimeOponent(PaddlePlayer2);
                }
                else if (playerThatUsedThePower == "P2")
                {
                    slimeOponent(PaddlePlayer1);
                }
                break;
            default:
                Debug.Log("Problem with power choose");
                break;
        }
    }

    private void crazyBall()
    {
        Debug.Log("crazy ball");
        pongBehavior.crazyBall();
    }

    private void zoneEnlarger()
    {
        Debug.Log("zone enlarger");
        zoneSwitcher.zoneEnlarger();
    }
    private void zoneShrinker()
    {
        Debug.Log("zone shrinker");
        zoneSwitcher.zoneShrinker();
    }
    private void freezeOponent(CelluloAgent playerToFreeze)
    {
        Debug.Log("freeze oponent");
        playerToFreeze.SetHapticBackdriveAssist(-1, -1, -1);
        if(playerToFreeze.tag == "Paddle1"){
            Invoke("clearHapticFeedbackPaddle1", 5f);

        }else if(playerToFreeze.tag == "Paddle2"){
            Invoke("clearHapticFeedbackPaddle2", 5f);
        } 
    }
    private void slimeOponent(CelluloAgent playerToSlime)
    {
        Debug.Log("slime oponent");
        playerToSlime.MoveOnMud();
        if(playerToSlime.tag == "Paddle1"){
            Invoke("clearHapticFeedbackPaddle1", 10f);

        }else if(playerToSlime.tag == "Paddle2"){
            Invoke("clearHapticFeedbackPaddle2", 10f);
        }
    }


    void clearHapticFeedbackPaddle1()
    {
        PaddlePlayer1.ClearHapticFeedback();
    }

    void clearHapticFeedbackPaddle2()
    {
        PaddlePlayer2.ClearHapticFeedback();
    }

    public void powerColors()
    {
        //reset the color of the cellulos after the game has started and the players have found their cellulo
        PaddlePlayer1.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.black, 0);
        PaddlePlayer2.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.black, 0);
        ListPower1 = gameManager.getPower1();
        ListPower2 = gameManager.getPower2();

        //assign the leds to the power
        int j = 0;
        for (int i = 0; i < ListPower1.Count; ++i)
        {
            assignLedToPower(PaddlePlayer1, ListPower1[i], j);
            j += 2;
        }
        j = 0;
        for (int i = 0; i < ListPower2.Count; ++i)
        {
            assignLedToPower(PaddlePlayer2, ListPower2[i], j);
            j += 2;
        }
    }

    public void assignLedToPower(CelluloAgent agent, string power, int LED)
    {
        switch (power)
        {
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

    public void buttonsRealCellulo(Color color, string player)
    {
        powerSwitch(findKey(color), player);
    }

    private string findKey(Color color)
    {
        foreach (string keyVar in colorPowerList.Keys)
        {
            if (colorPowerList[keyVar] == color)
            {
                return keyVar;
            }
        }
        return null;
    }

    public Color getColorButton(string s)
    {
        return colorPowerList[s];
    }

    public string getStringFromTag(string s)
    {
        return tagToStringDic[s];
    }
}