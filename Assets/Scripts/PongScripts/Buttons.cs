using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    static List<string> buttonNameList = new List<string>();

    public Powers powers;

    public Button P1power1, P1power2, P1power3, P2power1, P2power2, P2power3;

    void Awake(){
        powers = GameObject.Find("PowerManager").GetComponent<Powers>();
    }
    void Start()
    {
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
    }

    public void OnClicked(){
         string buttonName =  EventSystem.current.currentSelectedGameObject.name;
        if(buttonNameList.Contains(buttonName)){
            powers.handlePower(buttonName);
        }
    }   
}
