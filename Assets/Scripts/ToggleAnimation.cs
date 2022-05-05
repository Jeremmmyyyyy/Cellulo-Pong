using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    Toggle m_Toggle;
    Vector3 initLocalScale;
    Vector3 onClickLocalScale;
    float scale = 0.8f;
    Color selectedColor;
    Color notSelectedColor;
    private GameManager gameManager;
    private bool toggleP1Selected;
    private bool toggleP2Selected;
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
                gameManager.setColorCellulo1(m_Toggle.GetComponent<Toggle>().colors.normalColor);
                toggleP1Selected = true;

            }
            else
            if (transform.parent.tag == "P2")
            {
                gameManager.setColorCellulo2(m_Toggle.GetComponent<Toggle>().colors.normalColor);
                toggleP2Selected = true;
            }
        });

        //Initialise the Text to say the first state of the Toggle
        initLocalScale = m_Toggle.GetComponent<RectTransform>().localScale;
        onClickLocalScale = scale* initLocalScale;
        selectedColor = m_Toggle.GetComponent<Toggle>().colors.normalColor;
        notSelectedColor = selectedColor;
        notSelectedColor.a = 0.7f;

    }
    void Update()
    {
        gameManager.setToogleAreSelected(toggleP1Selected, toggleP2Selected);
        
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (change.isOn){
            m_Toggle.GetComponent<RectTransform>().localScale = onClickLocalScale;
        }
        else
        {
            m_Toggle.GetComponent<RectTransform>().localScale = initLocalScale;
        }
    }
}
