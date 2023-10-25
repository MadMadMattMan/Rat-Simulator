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

    private void Start()
    {
        GameOver = false;
        GameWon = false;

        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
    }

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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title Scene");
    }
}
