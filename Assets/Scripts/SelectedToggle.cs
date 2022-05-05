using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedToggle : MonoBehaviour
{

    private GameManager gameManager;
    private Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        toggle = GetSelectedToggle();
        gameManager.setColorCellulo1(toggle.colors.normalColor);
        Debug.Log(toggle.colors.normalColor);
    }

    Toggle GetSelectedToggle()
    {
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        foreach (var t in toggles)
            if (t.isOn) return t;  //returns selected toggle
        return null;           // if nothing is selected return null
    }
}
