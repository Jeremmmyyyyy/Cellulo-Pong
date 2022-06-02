using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    static List<string> buttonNameList = new List<string>();

    public Powers powers;

    public Button P1power1, P1power2, P1power3, P2power1, P2power2, P2power3;

    private GameManager gameManager;

    private List<Button> buttonList1 = new List<Button>();
    private List<Button> buttonList2 = new List<Button>();
    bool b;

    void Awake(){
        powers = GameObject.Find("Powers").GetComponent<Powers>();
    }
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        buttonNameList.Add("P1:1");
        buttonNameList.Add("P1:2");
        buttonNameList.Add("P1:3");
        buttonNameList.Add("P2:1");
        buttonNameList.Add("P2:2");
        buttonNameList.Add("P2:3");
        P1power1.onClick.AddListener(OnClicked);
        P1power2.onClick.AddListener(OnClicked);
        P1power3.onClick.AddListener(OnClicked);
        P2power1.onClick.AddListener(OnClicked);
        P2power2.onClick.AddListener(OnClicked);
        P2power3.onClick.AddListener(OnClicked);
        b = false;



    }

    public void Update()
    {

        if (gameManager.game_as_start() && !b)
        {
            buttonList1.Add(P1power1);
            buttonList1.Add(P1power2);
            buttonList1.Add(P1power3);
            buttonList2.Add(P2power1);
            buttonList2.Add(P2power2);
            buttonList2.Add(P2power3);
            listColorButton();
            b = true;
        }
    }

    public void OnClicked(){
         string buttonName =  EventSystem.current.currentSelectedGameObject.name;
        if(buttonNameList.Contains(buttonName)){
            powers.handlePower(buttonName);
        }
    }   

    private void listColorButton()
    {
        Debug.Log("JE RENTRE");
        int i = 0;
        foreach (Button b in buttonList1)
        {
            Debug.Log(i);
            var colors = b.colors;
            colors.normalColor = powers.getColorButton(gameManager.getPower1()[i]);
            Debug.Log(colors.normalColor);
            TextMeshProUGUI bText = b.GetComponentInChildren<TextMeshProUGUI>();
            bText.text = gameManager.getPower1()[i];
            i++;
        }
        i = 0;
        foreach (Button b in buttonList2)
        {
            var colors = b.colors;
            colors.normalColor = powers.getColorButton(gameManager.getPower2()[i]);
            TextMeshProUGUI bText = b.GetComponentInChildren<TextMeshProUGUI>();
            bText.text = gameManager.getPower2()[i];
            i++;
        }
    }
}
