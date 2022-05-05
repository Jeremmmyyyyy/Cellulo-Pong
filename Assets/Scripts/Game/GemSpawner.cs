using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    private GameManager gameManager;
    static bool gameStarted;
    Gem gemToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gemToSpawn = new Gem();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        gameStarted = gameManager.game_as_start();
    }
    void spawn()
    {
        Debug.Log("spawn called");
        if (gameStarted)
        {
            Debug.Log("spawned gem");
            Vector3 spawnPos = new Vector3(Random.Range(1.8f, 26.3f), 0f, Random.Range(-18.3f, -1.7f));
            GameObject spawnedObject = Instantiate(gemToSpawn.gameObject, spawnPos, transform.rotation);

        }
        Invoke("spawn", 10);
    }
}
