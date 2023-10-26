using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Script : MonoBehaviour
{

    public GameObject ControllerImage;
    public GameObject KeyboardPannel;

    //Sets controls image to keyboard as default
    private void Awake()
    {
        ControllerImage.SetActive(false);
        KeyboardPannel.SetActive(true);
    }

    //Toggles the image to controller to show and hides Keyboard panel
    public void ControllerToggle()
    {
        ControllerImage.SetActive(true);
        KeyboardPannel.SetActive(false);
    }
    //Toggles the image to controller to hide and shows Keyboard panel
    public void KeybaoardToggle()
    {
        ControllerImage.SetActive(false);
        KeyboardPannel.SetActive(true);
    }

}
