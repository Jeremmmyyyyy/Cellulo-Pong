using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareVolumeScript : MonoBehaviour
{
    public Animator m_Animator;
    public Button plusButton;
    public Button moinsButton;
    private GameManager gameManager;
    private AudioManager AM;
    private bool menuMode;

    // Start is called before the first frame update
    void Start()
    {
        int idxScene = SceneManager.GetActiveScene().buildIndex;
        if (idxScene != 0)
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        }
        AM = GameObject.Find("Audio Source").GetComponent<AudioManager>();

        if (gameManager == null)
        {
            menuMode = true;
        }
        else
        {
            menuMode = false;
        }
        Button btnplus = plusButton.GetComponent<Button>();
        Button btnmoins = moinsButton.GetComponent<Button>();
        btnplus.onClick.AddListener(TaskOnClickPlus);
        btnmoins.onClick.AddListener(TaskOnClickMoins);
    }

    // Update is called once per frame
    void TaskOnClickPlus()
    {
        if (!menuMode &&gameManager.getVolume() < 6)
        {
            gameManager.setVolume(gameManager.getVolume() + 1);
            m_Animator.SetInteger("Volume", gameManager.getVolume());
        }
        else
        {
            AM.VolumeUp();
            m_Animator.SetInteger("Volume", AM.getVolume());

        }
    }
    void TaskOnClickMoins()
    {
        if (!menuMode && gameManager.getVolume() > 0)
        {
            gameManager.setVolume(gameManager.getVolume() - 1);
            m_Animator.SetInteger("Volume", gameManager.getVolume());
        }
        else
        {
            AM.VolumeDown();
            m_Animator.SetInteger("Volume", AM.getVolume());

        }
    }
}
