using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//cette classe s'occupe de gerer toute la partie score
public class GameManager : MonoBehaviour
{

    //PUBLIC METHODS
    //TODO: mettre en public si on en a besoin
    private TextMeshProUGUI score1;
    private TextMeshProUGUI score2;
    public CelluloAgent celluloPlayer1;
    public CelluloAgent celluloPlayer2;
    public CelluloAgent pong;
    public CelluloAgent celluloPlayer1UI;
    private CelluloAgent celluloPlayer2UI;
    private Toggle toggleMute;


    // Start is called before the first frame update
    private int scorePlayer1;
    private int scorePlayer2;
    private bool gameAsStart = false;
    private Color winnerCol;
    private Color cellulo1Color;
    private Color cellulo2Color;
    private bool player1IsArrow;
    private bool gameCanStart;
    private bool toggleP1Selected;
    private bool toggleP2Selected;
    private float timeOfAGame = 2;
    private bool gameIsMute;
    private bool isGemCollectedP1;
    private bool isGemCollectedP2;
    private bool printDebugScore = true;
    private bool botIsGhost = false;
    private List<string> powerP1;
    private List<string> powerP2;



    void Start()
    {
        toggleP1Selected = false;
        toggleP2Selected = false;
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        player1IsArrow = false;
        gameIsMute = false;

        isGemCollectedP1 = false;
        isGemCollectedP2 = false;

        clearHaptic();
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        toggleUpdate();
    }

    void updateScore(){
        if(score1 != null && score2 != null){
            score1.text = scorePlayer1.ToString("00");
            score1.color = cellulo1Color;
            score2.text = scorePlayer2.ToString("00");
            score2.color = cellulo2Color;
        }else if(printDebugScore){
            Debug.Log("GAMEMANGER: change score to public if you want to use it");
            printDebugScore = false;
        }
    }

    void toggleUpdate(){
        if (toggleP1Selected && toggleP2Selected)
        {
            gameCanStart = true;
        }
    }

    private void clearHaptic(){
        celluloPlayer1.ClearHapticFeedback();
        celluloPlayer2.ClearHapticFeedback();
        pong.ClearHapticFeedback();
    }

    //changer le statut du jeu
    public void gameStatus(bool asBegan)
    {
        gameAsStart = asBegan;
        if(asBegan){
            clearHaptic();
        }
    }
    public bool game_as_start()
    {
        return gameAsStart;
    }
    public void updateScoreTag(string tag, int value, bool addOrSubstract) 
    {
        if (tag == "P1")
        {

            if (addOrSubstract == false)
            {
                scorePlayer1 -= value;
            }
            else
            {
                scorePlayer1 += value;
            }
        }
        else
        {
            if (addOrSubstract == false)
            {
                scorePlayer2 -= value;
            }
            else
            {
                scorePlayer2 += value;
            }
        }
    }
    // va update le score en fonction de si on a gagner ou perdu des points
    public void updateScore(GameObject whichPlayer, int value, bool addOrSubstract)
    {
        if (whichPlayer.CompareTag("P1"))
        {

            if (addOrSubstract == false)
            {
                scorePlayer1-= value;
            }
            else
            {
                scorePlayer1 += value;
            }
        }
        else
        {
            if (addOrSubstract == false)
            {
                scorePlayer2 -= value;
            }
            else
            {
                scorePlayer2+= value;
            }
        }

    }
    //
   
    public void collectGem(string tag) 
    {
        if (tag == "P1")
        {
            isGemCollectedP1 = true;
        }
        if (tag == "P2")
        {
            isGemCollectedP2 = true;
        }
    }
    public bool getGemIsCollectedP1()
    {
        return isGemCollectedP1;
    }
    public bool getGemIsCollectedP2()
    {
        return isGemCollectedP2;
    }
    public void setGemIsCollectedP1(bool bTaM)
    {
        isGemCollectedP1 = bTaM;
    }
    public void setGemIsCollectedP2(bool bTaM)
    {
        isGemCollectedP2 = bTaM;
    }
    
    public int getScore(GameObject whichPlayer)
    {
        if (whichPlayer.CompareTag("P1"))
        {
            return scorePlayer1;
        }
        else
        {
            return scorePlayer2;
        }
    }

    public string winnerIs()
    {

        if (scorePlayer1 > scorePlayer2)
        {
            winnerCol = cellulo1Color;
            return "Player 1";
        }
        else if (scorePlayer1 < scorePlayer2)
        {
            winnerCol = cellulo2Color;
            return "Player 2";
        }
        else
        {
            winnerCol = Color.yellow;
            return "NO ONE...";

        }
    }

    public Color winnerColor()
    {
        return winnerCol;
    }

    public void setColorCellulo1(Color c)
    {
        cellulo1Color = c;
        celluloPlayer1.SetVisualEffect(VisualEffect.VisualEffectConstAll, c, 100);
        celluloPlayer1UI.SetVisualEffect(VisualEffect.VisualEffectConstAll, c, 100);
    }

    public void setColorCellulo2(Color c)
    {
        cellulo2Color = c;
        celluloPlayer2.SetVisualEffect(VisualEffect.VisualEffectConstAll, c, 100);
        celluloPlayer2UI.SetVisualEffect(VisualEffect.VisualEffectConstAll, c, 100);
    }

    public void setPlayer1IsArrowTo(bool b)
    {
        player1IsArrow = b;
    }

    public string getPlayerCommand(string playerTag)
    {
        if(playerTag == "P1")
        {
            if (player1IsArrow)
            {
                return "arrow";
            }
            else
            {
                return "wasd";
            }
        }
        else if(playerTag == "P2")
        {
            if (player1IsArrow)
            {
                return "wasd";
            }
            else
            {
                return "arrow";
            }
        }
        else
        {
            return "";
        }
    }
    public bool getPlayer2IsArrow()
    {
        return !player1IsArrow;
    }
    public void setTooglePowerAreSelected(bool tP1, bool tP2, string power)
    {
        if (tP1)
        {
            toggleP1Selected = true;
        }
        if (tP2)
        {
            toggleP2Selected = true;
        }
    }



    public void setToogleAreSelected(bool tP1, bool tP2)
    {
        if (tP1)
        {
            toggleP1Selected = true;
        }
        if (tP2)
        {
            toggleP2Selected = true;
        }
    }
    public bool getGameCanStart()
    {
        return gameCanStart;
    }
    public void setTimeOfAGame(float minutes)
    {
        timeOfAGame = minutes;
    }
    public float getTimeOfAGame()
    {
        return timeOfAGame;
    }

    public bool getGameIsMute()
    {
        return gameIsMute;
    }
    public void setGameIsMute(bool b)
    {
        gameIsMute = b;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public bool getBotIsGhost(){
        return botIsGhost;
    }

    public void setBotIsGhost(bool setBool){
        botIsGhost = setBool;
    }

    public void changeMovingBehavior(bool change){
        if(change){
            celluloPlayer1.ClearHapticFeedback();
            celluloPlayer2.ClearHapticFeedback();
            celluloPlayer1.MoveOnStone();
            celluloPlayer2.MoveOnStone();
        }else{
            celluloPlayer1.ClearHapticFeedback();
            celluloPlayer2.ClearHapticFeedback();
            celluloPlayer1.SetCasualBackdriveAssistEnabled(true);
            celluloPlayer2.SetCasualBackdriveAssistEnabled(true);
        }

    }

}
