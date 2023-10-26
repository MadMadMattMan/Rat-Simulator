using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverviewer : MonoBehaviour
{
    public static bool GameOver = false;
    public static bool GameWon = false;

    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

    //Sets game so that player has not lost nor won yet
    private void Start()
    {
        GameOver = false;
        GameWon = false;

        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
    }

    //Checks for game loss or win
    void Update()
    {
        if (GameOver)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        if (GameWon)
        {
            GameWinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //Button code that closes the game
    public void Exit()
    {
        Application.Quit();
    }
}
