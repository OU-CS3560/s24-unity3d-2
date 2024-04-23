using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;

    public void Setup()
    {
        MovementController script = player.GetComponent<MovementController>();
        MovementController script2 = player2.GetComponent<MovementController>();

        script.hi.enabled = false;
        script2.hi.enabled = false;
        
        gameObject.SetActive(true);
    }
}
