using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Script : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
