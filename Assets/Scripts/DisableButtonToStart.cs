using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtonToStart : MonoBehaviour
{
    private GameManager gameManager;
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        b.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getGameCanStart())
            b.interactable = true;
        else
            b.interactable = false;
    }
}
