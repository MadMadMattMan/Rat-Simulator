using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Script : MonoBehaviour
{
    //Resets time if game was pasued
    public void Awake()
    {
        Time.timeScale = 1.0f;
    }


    //just button code
    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
