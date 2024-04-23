using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int time = 0;
    public TextMeshProUGUI Ctext;
    public GameObject player1;
    public GameObject player2;
    //public GameObject timer;
    public GameObject screen;

    void Start()
    {
        StartCoroutine(CountdownStart());
    }
    
    IEnumerator CountdownStart()
    {
        while(time > 0)
        {

            Ctext.text = time.ToString();

            yield return new WaitForSeconds(1.22222f);

            if(time == 1)
            {
                yield return new WaitForSeconds(0.3777777f);
            }
            
            time--;

        }

        Ctext.text = "GO!";

        player1.SetActive(true);
        player2.SetActive(true);
        //timer.SetActive(true);


        screen.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        Ctext.gameObject.SetActive(false);
        
    }
}
