using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class switchTransition : MonoBehaviour
{
    private Animator mAnimator;
    public Button yourButton;
    private bool isSwitch;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        isSwitch = true;
        mAnimator = GetComponent<Animator>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void TaskOnClick()
    {
        if (isSwitch)
        {
            mAnimator.SetTrigger("IsSwitch");
            isSwitch = false;
            gameManager.setPlayer1IsArrowTo(true);
        }
        else
        {
            mAnimator.SetTrigger("IsNormal");
            isSwitch = true;
            gameManager.setPlayer1IsArrowTo(false);
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
