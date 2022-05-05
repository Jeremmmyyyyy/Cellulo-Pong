using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTimerChange : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onPlusClick()
    {
        gameManager.setTimeOfAGame(gameManager.getTimeOfAGame() + 1);
    }

    public void onMoinsClick()
    {
        gameManager.setTimeOfAGame(gameManager.getTimeOfAGame() - 1);
    }
}
