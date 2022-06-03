using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonColor : MonoBehaviour
{
    private GameManager gameManager;
    private Light the_light;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        the_light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.game_as_start())
        {
            the_light.color = gameManager.getColor(this.tag);
        }

    }
}
