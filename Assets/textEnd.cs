using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textEnd : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        text.text = gameManager.getScoreWithTag(this.tag).ToString("00");

    }
}
