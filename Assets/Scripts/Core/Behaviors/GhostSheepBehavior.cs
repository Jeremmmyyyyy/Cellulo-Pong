using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GhostSheepBehavior : AgentBehaviour
{
    float random;
    //Adjustement for the speed of the ghosSheep (slower than the other cellulos)
    public float accelAdjust = 2.0f;
    //treshold distance that the Sheep tries to maintain with the other cellulos
    public float treshhold = 10.0f;
    //Min random value to change state
    public float randomMin = 10.0f;
    //Max random value to change state
    //If Min == Max no state change -> for testing
    public float randomMax = 10.0f;
    private GameManager gameManager;

    //Importing all the audio sources
    private AudioSource[] audio_source;
    private AudioSource wolf;
    private AudioSource sheep;
    private AudioSource lose;




    public void Start()
    {
        agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 100);
        gameObject.tag = "Sheep";
        random = createNewRandom();
        //Invoke the state change after a random period
        Invoke("changeStatus", createNewRandom());
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //Loading all the audio sources
        audio_source = GetComponents<AudioSource>();
        if (audio_source.Length != 3)
        {
            Debug.Log("No audio source detected / or audio source missing need 3");
        }
        lose = audio_source[0];
        wolf = audio_source[1];
        sheep = audio_source[2];
    }

    //creates a new random number between min and max
    float createNewRandom()
    {
        if (randomMin == randomMax)
        {
            return 100.0f;
        }
        return Random.Range(randomMin, randomMax);
    }

    //change the status from ghost to sheep or vice versa
    //plays the correct sound and change the tag of the cellulo
    void changeStatus()
    {

        if (gameManager.game_as_start())
        {
            if (gameObject.tag == "Sheep")
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.red, 100);
                gameObject.tag = "Ghost";
                wolf.Play();

            }
            else if (gameObject.tag == "Ghost")
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 100);
                gameObject.tag = "Sheep";
                sheep.Play();
            }
        }



        //recall itself after a new random period
        Invoke("changeStatus", createNewRandom());
    }
    public void Update()
    {

        if (!gameManager.game_as_start())
        {
            agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 100);
            gameObject.tag = "Sheep";
        }
        if (gameManager.getGameIsMute())
        {
            foreach (AudioSource a in audio_source)
            {
                a.mute = true;
            }
        }
        if (!gameManager.getGameIsMute())
        {
            foreach (AudioSource a in audio_source)
            {
                a.mute = false;
            }
        }
    }

    //finds the closest ennemy to the GhostSheep and returns it so it can be purchased
    public GameObject FindClosestEnemy()
    {
        GameObject[] P1 = GameObject.FindGameObjectsWithTag("P1");
        GameObject[] P2 = GameObject.FindGameObjectsWithTag("P2");
        GameObject[] players = P1.Concat(P2).ToArray();
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }

    //compare it's distance to the other cellulos with help of te treshold distance
    //returns a Vector3 that corresponds to the direction it has to flee
    public Vector3 FleeEnnemies()
    {

        List<Vector3> positions = new List<Vector3>();
        GameObject[] P1 = GameObject.FindGameObjectsWithTag("P1");
        GameObject[] P2 = GameObject.FindGameObjectsWithTag("P2");
        GameObject[] players = P1.Concat(P2).ToArray();

        Vector3 averagePosition;

        foreach (GameObject player in players)
        {

            if (Vector3.Distance(transform.position, player.transform.position) <= treshhold)
            {
                //if the player are in the treshold distance add them to the list of robots to flee
                positions.Add(player.transform.position);

            }
            else
            {
                positions.Remove(player.transform.position);
            }
        }
        //average position to flee
        averagePosition = GetMeanVector(positions);

        return averagePosition;
    }

    // calculate the mean vector from a list of multiple Vector3
    private Vector3 GetMeanVector(List<Vector3> positions)
    {
        if (positions.Count == 0)
        {
            return Vector3.zero;
        }

        float x = 0f;
        float y = 0f;
        float z = 0f;

        foreach (Vector3 pos in positions)
        {
            x += pos.x;
            y += pos.y;
            z += pos.z;
        }
        return new Vector3(x / positions.Count, y / positions.Count, z / positions.Count);
    }

    //recalculate the path the GhostSheep has to follow depending on it's mode
    public override Steering GetSteering()
    {

        GameObject closest = FindClosestEnemy();
        Steering steering = new Steering();
        if (gameManager.game_as_start())
        {

            Vector3 directionHunt = closest.transform.position - agent.transform.position;
            Vector3 directionFlee = agent.transform.position - FleeEnnemies();
            Vector3 usedBehavior;

            if (gameObject.tag == "Sheep")
            {
                gameManager.setBotIsGhost(false);
                if ((agent.transform.position - directionFlee) != Vector3.zero)
                {
                    usedBehavior = directionFlee;
                }
                else
                {
                    usedBehavior = Vector3.zero;
                }

            }
            else
            {
                gameManager.setBotIsGhost(true);
                usedBehavior = directionHunt;
            }

            steering.linear = usedBehavior * (agent.maxAccel);
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, (agent.maxAccel - accelAdjust)));

        }
        return steering;
    }

    //Manages the score in the case the GhostShepp is a Ghost and collides with a cellulo
    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Ghost")
        {
            if (collision.gameObject.CompareTag("P1") || collision.gameObject.CompareTag("P2"))
            {
                gameManager.updateScore(collision.gameObject, 1, false);
                lose.Play();
            }
        }

    }

}