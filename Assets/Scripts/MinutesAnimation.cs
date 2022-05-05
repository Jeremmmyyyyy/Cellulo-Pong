using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MinutesAnimation : MonoBehaviour
{
    private Animator mAnimator;
    public Button btn1;
    public Button btn2;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        btn1.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        mAnimator.SetTrigger("isClick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
