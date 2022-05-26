using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayChoiceMenu : MonoBehaviour
{
    public Button yourButton;
    private GameManager gameManager;
    public GameObject canvaChoice;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (gameManager.checkSizeMenu())
        {
            canvaChoice.SetActive(false);
        }
    }
}
