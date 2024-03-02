using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 3f;
    public bool timeRun = false;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        time = time * 60f + 2f;
        timeRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRun)
        {
            if(time > 2f)
            {
                time = time - Time.deltaTime;
                DisplayTime(time);
            }
        }
    }
    void DisplayTime (float timedisplay)
    {
        timedisplay = timedisplay - 1;
        float minutes = Mathf.FloorToInt(timedisplay / 60);
        float seconds = Mathf.FloorToInt(timedisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
