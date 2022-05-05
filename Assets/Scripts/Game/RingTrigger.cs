using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingTrigger : MonoBehaviour

{
    // Start is called before the first frame update
    ///private Score score;
    private GameObject player;
    private GameManager gameManager;
    //private Score score;
    private AudioSource win;

    void Start()
    {
        GameObject[] sheep = GameObject.FindGameObjectsWithTag("Sheep");
        //score = GetComponent<Score>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //audio source for the win sound
        win = GetComponent<AudioSource>();
        if (win == null){
            Debug.Log("No audio source found for the loose point");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)

    {

        if (other.transform.parent.gameObject.CompareTag("Sheep"))
        {
            ///ADD method to ghost sheep to check which player is closest to Sheep and add score accordingly
            ///

            player = other.transform.parent.gameObject.GetComponent<GhostSheepBehavior>().FindClosestEnemy();
            gameManager.updateScore(player, 1, true);
            win.Play();
        }

    }

    //Upon collision with another GameObject, this GameObject will reverse direction

}