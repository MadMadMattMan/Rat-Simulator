using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_Script : MonoBehaviour
{
    //Resets time
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    //button code that changes scene
    public void OpenTitle()
    {
        SceneManager.LoadScene("Title Scene");
    }

    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }
}
