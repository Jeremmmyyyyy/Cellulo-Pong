using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupPower : MonoBehaviour
{

    List<Toggle> togglesSelected = new List<Toggle>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addToggle(Toggle t)
    {
        int size = togglesSelected.Count;
        if (size == 3)
        {
            removeToggle(togglesSelected[2]);
        }
        t.isOn = true;
        togglesSelected.Add(t);

    }
    public void removeToggle(Toggle t)
    {
        int size = togglesSelected.Count;
        if (size > 0)
        {
            t.isOn = false;
            togglesSelected.Remove(t);
        }


    }



    public void GetSelectedToggle()
    {

        Debug.Log("ALL : \n");
        Toggle[] toggleList = this.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggleList)
        {
            Debug.Log(toggle +" " + toggle.isOn);
        }
        Debug.Log("\n\n LISTE : \n");
        foreach (Toggle toggle in togglesSelected)
        {
            Debug.Log(toggle + " " + toggle.isOn);
        }
    }
    
}
