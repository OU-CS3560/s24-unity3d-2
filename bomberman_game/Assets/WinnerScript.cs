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

    void Update()
    {
        MovementController score = player.GetComponent<MovementController>();
        MovementController score2 = player2.GetComponent<MovementController>();

        if(score.deaths > score2.deaths)
        {
            winner.text = "BLACK CHICKEN WINS!";
        }
        else if(score.deaths < score2.deaths)
        {
            winner.text = "WHITE CHICKEN WINS!";
        }
        else
        {
            winner.text = "TIE!";
        }
    }


}
