using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePower : MonoBehaviour
{
    Toggle m_Toggle;
    private GameManager gameManager;
    private bool toggleP1Selected;
    private bool toggleP2Selected;

    //chaque pouvoir aura son tag afin de savoir lequel a été selectionné

    void Start()
    {

        toggleP1Selected = false;
        toggleP2Selected = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
            if (transform.parent.tag == "P1")
            {
                //faire qqch avec le game manager
                toggleP1Selected = true;

            }
            else
            if (transform.parent.tag == "P2")
            {
                //faire qqch avec le game manager
                toggleP2Selected = true;
            }
        });

    }
    void Update()
    {
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {

            transform.parent.GetComponent<ToggleGroupPower>().addToggle(change);
        }
        if (!change.isOn)
        {
            transform.parent.GetComponent<ToggleGroupPower>().removeToggle(change);
        }
    }
}
