using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSwitcher : MonoBehaviour
{
    private static string[] zones = {"Back Zones", "Mid Zones", "Center Zones"};
    private static GameObject[] zonesObjectList;
    //public Button yourButton;
    private int i;
    public GameObject BackZone;
    public GameObject MidZone;
    public GameObject CenterZone;
    // Start is called before the first frame update
    void Start()
    {
        string startZone = zones[0];
        i = 0;
        
        //zones = new List<GameObject> {BackZone, MidZone, CenterZone};
        zonesObjectList = new GameObject[] {BackZone, MidZone, CenterZone};
        BackZone.SetActive(true);
        MidZone.SetActive(false);
        CenterZone.SetActive(false);
        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void zoneEnlarger(){
        Debug.Log("zone enlarger");
        if (i != 2){
            zonesObjectList[i].SetActive(false);
            ++i;
            zonesObjectList[i].SetActive(true);
        }
    }

    public void zoneShrinker(){
        Debug.Log("zone shrinker");
        if(i != 0){
            zonesObjectList[i].SetActive(false);
            --i;
            zonesObjectList[i].SetActive(true);
        }
    }
}