using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareVolumeScript : MonoBehaviour
{
    public Animator m_Animator;
    public Button plusButton;
    public Button moinsButton;
    private int volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = 0;
        Button btnplus = plusButton.GetComponent<Button>();
        Button btnmoins = moinsButton.GetComponent<Button>();

        btnplus.onClick.AddListener(TaskOnClickPlus);
        btnmoins.onClick.AddListener(TaskOnClickMoins);
    }

    // Update is called once per frame
    void TaskOnClickPlus()
    {
        if (volume <= 6)
        {
            volume += 1;
            m_Animator.SetInteger("Volume", volume);
        }
    }
    void TaskOnClickMoins()
    {
        if (volume >= 0)
        {
            volume -= 1;
            m_Animator.SetInteger("Volume", volume);
        }
    }
}
