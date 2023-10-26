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
            if (!PenguinScript.GivenItem)
            {
                if (ControllerMode.isOn)
                    Text.text = "use 'A' to talk to Penguin";
                else
                    Text.text = "use 'E' to talk to Penguin";
                promptTextBelow.SetActive(true);
            }
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


    ///ALL FOR QUICK MESSAGE SYSTEM

    public static string QuickMessageTxt;
    public static bool StartQuickMessageBool;

    //When void is called from another script, set string value to the msg attached. Set the bool to true to start quick message
    public static void StartQuickMessage(string msg)
    {
        QuickMessageTxt = msg;
        StartQuickMessageBool = true;
    }

    //Check if Startmessage bool is true and start quickmessage while setting the message of the Quick Message and then toggles the bool to false
    private void Update()
    {
        if (StartQuickMessageBool)
        {
            StartQuickMessageBool = false;
            SetQuickMessage();
        }
    }

    private void SetQuickMessage()
    {
        //Filters out if the message is null
        if (QuickMessageTxt != null)
        {
            //Stops all Coroutines and starts a new one with the latest quickmessagetext to stop glitchy overlaps
            StopAllCoroutines();
            StartCoroutine(QuickMessage(QuickMessageTxt));
        }
    }

    public IEnumerator QuickMessage(string msg)
    {
        //Gets current text string and if the gameObject is active and stores it in variables
        string CurrentText = StaticText.text;
        bool CurrentState = StaticText.gameObject.activeSelf;

        //Sets current text to desired message text and makes the text gameobject visable
        StaticText.text = msg;
        StaticText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        //After waiting for 2 seconds, reset text to what is was before and to the
        StaticText.text = CurrentText;
        if (!CurrentState)
            StaticText.gameObject.SetActive(false);
        //removes quick message text
        QuickMessageTxt = null;
    }
}
