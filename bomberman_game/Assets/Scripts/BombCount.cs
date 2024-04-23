using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombCount : MonoBehaviour
{

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
        Bomb script = player.GetComponent<Bomb>();
        score.text = "" + script.bombs_remaining;
    }
}
