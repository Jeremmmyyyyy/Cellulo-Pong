using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCellulo : MonoBehaviour
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

    public void OnCollisionEnter(Collision collision)
    {
        if ((gameObject.tag == "P1") && ((collision.gameObject.tag != "Sheep") && (collision.gameObject.tag != "Ghost")));
        {
            if (gameManager.getGemIsCollectedP1())
            {
                gameManager.updateScoreTag(gameObject.tag, 2, true);
                gameManager.updateScoreTag("P2", 2, false);
                gameManager.setGemIsCollectedP1(false);
            }
            
        }
        if ((gameObject.tag == "P2") && ((collision.gameObject.tag != "Sheep") && (collision.gameObject.tag != "Ghost")))
        {

            if (gameManager.getGemIsCollectedP2())
            {
                gameManager.updateScoreTag(gameObject.tag, 2, true);
                gameManager.updateScoreTag("P1", 2, false);
                gameManager.setGemIsCollectedP2(false);

            }
        }
    }
}
