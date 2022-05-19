using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenuAfterAnim : MonoBehaviour
{
    public Animator anim;
    public GameObject settings;
    public GameObject rules;
    public GameObject play;
    public GameObject quit;


    // Start is called before the first frame update
    void Start()
    {
        if (!anim) anim = GetComponent<Animator>();
    }


    public void playAnim()
    {
        if(anim)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("IsClose")) {
                Debug.Log("lalaa");
                StartCoroutine(DelayedDead(anim.GetCurrentAnimatorStateInfo(0).length));
            }
        }

      
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