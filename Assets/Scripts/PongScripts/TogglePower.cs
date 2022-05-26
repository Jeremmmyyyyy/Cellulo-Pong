using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePower : MonoBehaviour
{
    Toggle m_Toggle;

    //chaque pouvoir aura son tag afin de savoir lequel a été selectionné

    void Start()
    {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
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
        else
        {
            transform.parent.GetComponent<ToggleGroupPower>().removeToggle(change);
        }
    }
}
