using UnityEngine;

public class Gem : MonoBehaviour
{
    private GameManager gameManager;
    static bool gameStarted;
    private bool isActive;
    private bool isCollided;
    private AudioSource[] audio_source;
    private AudioSource gem;
    public AudioClip collected;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        this.gameObject.transform.position = new Vector3(Random.Range(1.8f, 26.3f), 0f, Random.Range(-18.3f, -1.7f));
        isActive = true;
        this.gameObject.SetActive(true);
        isCollided = false;
        spawn();
        gem = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameStarted = gameManager.game_as_start();
    }

    void spawn()
    {
        if (gameStarted && !isActive && isCollided)
        {
            Vector3 spawnPos = new Vector3(Random.Range(1.8f, 26.3f), 0f, Random.Range(-18.3f, -1.7f));
            this.gameObject.transform.position = spawnPos;
            this.gameObject.SetActive(true);
            isCollided = false;
            gem.Play();
        }
        Invoke("spawn", 10);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent.gameObject.CompareTag("P1") || col.transform.parent.gameObject.CompareTag("P2"))
        {
            AudioSource.PlayClipAtPoint(collected, new Vector3(14, 48, -10), 100.0f);
            gameManager.collectGem(col.transform.parent.gameObject.tag);
            isActive = false;
            isCollided = true;
            this.gameObject.SetActive(false);
        }
    }
}