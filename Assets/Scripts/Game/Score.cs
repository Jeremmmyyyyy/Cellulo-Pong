using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private int scorePlayer1;
    private int scorePlayer2;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;


    private void Start()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
    }


    // Update is called once per frame
    void Update()
    {

        score1.text = scorePlayer1.ToString("00");
        score2.text = scorePlayer2.ToString("00");
    }



    /// This method updates the score by adding or substracting the current score with a certain value
    /// @param value : value that you want to add/substract to the score
    /// @param addOrSubstract : if false, will use substraction, if true will use addition 
    public void updateScore(GameObject whichPlayer, int value, bool addOrSubstract)
    {
        if (whichPlayer.CompareTag("P1"))
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
}
