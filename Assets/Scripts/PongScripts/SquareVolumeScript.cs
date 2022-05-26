using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareVolumeScript : MonoBehaviour
{
    public Animator m_Animator;
    public Button plusButton;
    public Button moinsButton;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Button btnplus = plusButton.GetComponent<Button>();
        Button btnmoins = moinsButton.GetComponent<Button>();

        btnplus.onClick.AddListener(TaskOnClickPlus);
        btnmoins.onClick.AddListener(TaskOnClickMoins);
    }

    // Update is called once per frame
    void TaskOnClickPlus()
    {
        
        if (gameManager.getVolume() < 6)
        {
            gameManager.setVolume(gameManager.getVolume() + 1);
            m_Animator.SetInteger("Volume", gameManager.getVolume());
        }
    }
    void TaskOnClickMoins()
    {
        if (gameManager.getVolume() > 0)
        {
            gameManager.setVolume(gameManager.getVolume() - 1);
            m_Animator.SetInteger("Volume", gameManager.getVolume());
        }
    }
}
