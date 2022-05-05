using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/**
  le timer
  ce timer affichera le temps qu'il reste a la partie
*/
public class Timer : MonoBehaviour
{
    private float initTimerValue;
    private float timeRemaining;
    private bool timerIsRunning;
    private TextMeshProUGUI timerText;
    public Slider slider;
    //private float maxMinutes;
    private GameManager gameManager;
    public GameObject canvas_end;
    public Button plusButton;
    public Button moinsButton;
    public TextMeshProUGUI MenuChoiceTimer;


    public void Awake() {
        initTimerValue = Time.time;

    }

    // Start is called before the first frame update
    public void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        timerText = GetComponent<TextMeshProUGUI>();
        timerIsRunning = false;
        canvas_end.SetActive(false);


    }

    // Update is called once per frame. SI le jeu a pas commencer le timer ne commence pas
    public void Update() {

        if (gameManager.getTimeOfAGame() > 1)
        {
            moinsButton.interactable = true;
        }
        else
        {
            moinsButton.interactable = false;
        }
        if (!gameManager.game_as_start())
        {
            timeRemaining = gameManager.getTimeOfAGame() * 60;
            timerText.text = string.Format("{0:00}:{1:00}", gameManager.getTimeOfAGame(), 0);
        }
        if (gameManager.game_as_start())
        {
            timerIsRunning = true;
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.gameStatus(false);
                canvas_end.SetActive(true);

            }
        }
        //changer la valeur de la taille du slider en fcontion du temps
        slider.value = slider.maxValue - (timeRemaining / 60)/ gameManager.getTimeOfAGame();
        MenuChoiceTimer.text = string.Format("{0}", gameManager.getTimeOfAGame());




    }
    //afficher le temps
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
