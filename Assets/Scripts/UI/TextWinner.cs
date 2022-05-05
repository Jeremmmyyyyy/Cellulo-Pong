using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextWinner : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameManager gameManager;
    // Start is called before the first frame update
    //va donner le text et la couleur a mettre en fonction du winner
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        text.text = gameManager.winnerIs();
        text.color = gameManager.winnerColor();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
