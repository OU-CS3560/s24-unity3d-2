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
