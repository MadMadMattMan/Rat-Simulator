using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverviewer : MonoBehaviour
{
    public static bool GameOver = false;

    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

    private void Start()
    {
        GameOver = false;

        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
    }

    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0.5f;

        }    
    }
}
