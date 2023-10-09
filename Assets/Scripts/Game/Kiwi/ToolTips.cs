using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ToolTips : MonoBehaviour
{
    public Toggle ControllerMode;
    public GameObject promptTextBelow;
    public static GameObject promptTextStatic;

    private TextMeshProUGUI Text;
    public static TextMeshProUGUI StaticText;

    private void Awake()
    {
        promptTextBelow.SetActive(false);
        Text = promptTextBelow.GetComponent<TextMeshProUGUI>();
        StaticText = promptTextBelow.GetComponent<TextMeshProUGUI>();
    }

    //Tooltips Script
    ///As the player walks into a interact zone, the tooltip text will appear and guide the user on what button/key to press
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shop Zone")
        {
            //Tooltips are only for Xbox controller as can't detect which controller is connected
            if (ControllerMode.isOn)
                Text.text = "use 'A' to open shop";
            else
                Text.text = "use 'E' to open shop";

            promptTextBelow.SetActive(true);
        }

        if (collision.gameObject.name == "Morepork Interact Zone")
        {
            if (ControllerMode.isOn)
                Text.text = "use 'A' to talk to Morepork";
            else
                Text.text = "use 'E' to talk to Morepork";
            promptTextBelow.SetActive(true);
        }

        if (collision.gameObject.name == "Penguin Interact Zone")
        {
            if (ControllerMode.isOn)
                Text.text = "use 'A' to talk to Penguin";
            else
                Text.text = "use 'E' to talk to Penguin";
            promptTextBelow.SetActive(true);
        }

        if (collision.gameObject.name == "Egg Interact Zone")
        {
            if (ControllerMode.isOn)
                Text.text = "use 'A' to use selected item on Egg";
            else
                Text.text = "use 'E' to use selected item on Egg";
            promptTextBelow.SetActive(true);
        }
    }

    //On player exit, remove the text
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shop Zone")
        {
            promptTextBelow.SetActive(false);
            ShopMenuScript.OpenCloseShop("closed");
        }

        if (collision.gameObject.name == "Egg Interact Zone")
        {
            promptTextBelow.SetActive(false);
        }

        if (collision.gameObject.name == "Morepork Interact Zone")
        {
            promptTextBelow.SetActive(false);
        }

        if (collision.gameObject.name == "Penguin Interact Zone")
        {
            promptTextBelow.SetActive(false);
        }
    }

    public static IEnumerator QuickMessage(string msg)
    {
        string CurrentText = StaticText.text;
        bool CurrentState = StaticText.gameObject.activeSelf;
        StaticText.text = msg;
        StaticText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        StaticText.text = CurrentText;
        if (!CurrentState)
            StaticText.gameObject.SetActive(false);
    }
}
