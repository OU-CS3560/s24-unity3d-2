using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerShow : MonoBehaviour
{
    public GameObject player;

    public GameObject BlastPicture;
    public GameObject ShieldPicture;
    public GameObject PushPicture;
    
    // Update is called once per frame
    void Update()
    {
        MovementController checker = player.GetComponent<MovementController>();
        Rigidbody2D mass_check = player.GetComponent<Rigidbody2D>();
        Bomb bomb_check = player.GetComponent<Bomb>();

        if(checker.shield == true)
        {
            ShieldPicture.SetActive(true);
        }
        else
        {
            ShieldPicture.SetActive(false);
        }

        if(mass_check.mass == 1000000)
        {
            PushPicture.SetActive(true);
        }
        else
        {
            PushPicture.SetActive(false);
        }

        if(bomb_check.explosion_radius > 1)
        {
            BlastPicture.SetActive(true);
        }
        else
        {
            BlastPicture.SetActive(false);
        }
        
    }
}
