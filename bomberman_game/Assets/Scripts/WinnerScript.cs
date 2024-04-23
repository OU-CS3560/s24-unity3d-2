using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;

    public TMP_Text winner;

    private void Update()
    {
        MovementController score = player.GetComponent<MovementController>();
        MovementController score2 = player2.GetComponent<MovementController>();

        winner.text = who_win(score.deaths, score2.deaths);
    }

    /// \brief A function that compares two players' scores and determines the winner
    /// @param[in] score the score of the black chicken
    /// @param[in] score2 the score of the white chicken
    /// \return string that reveals the winner.
    public string who_win(int score, int score2)
    {
        if(score > score2)
        {
            return "BLACK CHICKEN WINS!";
        }
        else if(score < score2)
        {
            return "WHITE CHICKEN WINS!";
        }
        else
        {
            return "TIE!";
        }
    }


}
