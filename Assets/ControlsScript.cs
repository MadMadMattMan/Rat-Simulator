using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScript : MonoBehaviour
{

    public GameObject ControllerImage;
    public GameObject KeyboardPannel;

    private void Awake()
    {
        ControllerImage.SetActive(false);
        KeyboardPannel.SetActive(true);
    }

    public void ControllerToggle()
    {
        ControllerImage.SetActive(true);
        KeyboardPannel.SetActive(false);
    }

    public void KeybaoardToggle()
    {
        ControllerImage.SetActive(false);
        KeyboardPannel.SetActive(true);
    }

}
