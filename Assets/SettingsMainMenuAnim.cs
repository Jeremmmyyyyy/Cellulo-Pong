using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMainMenuAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator m_Animator;
    public Button yourButton;
    public Button yourButtonExit;

    public GameObject settings;
    public GameObject rules;
    public GameObject play;
    public GameObject quit;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        Button btnExit = yourButtonExit.GetComponent<Button>();

        btn.onClick.AddListener(TaskOnClick);
        btnExit.onClick.AddListener(TaskOnClickExit);
    }

    void TaskOnClick()
    {
        m_Animator.SetTrigger("IsOpen");
    }
    void TaskOnClickExit()
    {
        m_Animator.SetTrigger("IsClose");
        StartCoroutine(DelayedDead(m_Animator.GetCurrentAnimatorStateInfo(0).length));

    }
    IEnumerator DelayedDead(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        settings.SetActive(true);
        rules.SetActive(true);
        play.SetActive(true);
        quit.SetActive(true);
    }
}
