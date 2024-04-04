using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu ()
    {
        SceneManager.LoadScene(0);
    }
}
