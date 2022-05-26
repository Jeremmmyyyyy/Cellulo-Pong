using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powers : MonoBehaviour
{
    public CelluloAgent PaddlePlayer1;
    public CelluloAgent PaddlePlayer2;
    public CelluloAgent Ball;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void handlePower(string buttonName){
        string[] player_power = buttonName.Split(':');
        int power = Int32.Parse(player_power[1]);
        Debug.Log(player_power[0]);
        Debug.Log(player_power[1]);

        
        //TODO: get les listes du gamemanager et choisir la bonne fonction

    }
}
