using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupPower : MonoBehaviour
{

    List<Toggle> togglesSelected = new List<Toggle>();
    private GameManager gameManager;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


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
        GetSelectedToggle();

    }
    public void removeToggle(Toggle t)
    {
        int size = togglesSelected.Count;
        if (size > 0)
        {
            t.isOn = false;
            togglesSelected.Remove(t);
        }
        GetSelectedToggle();

    }



public void GetSelectedToggle()
    {
        //Toggle[] toggleList = this.GetComponentsInChildren<Toggle>();
        List<string> tagList = new List<string>();
        foreach (Toggle t in togglesSelected)
        {

            tagList.Add(t.tag);
        }
        gameManager.setListPower(this.tag, tagList);
    }
}
