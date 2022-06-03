using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ball")
        {
            if (this.gameObject.tag == "LWall")
            {
                gameManager.updateScoreTag("P2", 1, true);
            }
            else
            {
                gameManager.updateScoreTag("P1", 1, true);
            }
        }

    }
}