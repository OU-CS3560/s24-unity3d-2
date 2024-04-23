using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int death = 0;
    public GameObject player;
    
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementController script = player.GetComponent<MovementController>();
        death = script.deaths;
        score.text = "Score: " + death;
    }
}
