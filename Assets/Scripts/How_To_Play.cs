using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class How_To_Play : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;


    private void Awake()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
    }

    public void NextPage()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void title()
    {
        SceneManager.LoadScene("Title Scene");
    }
}
