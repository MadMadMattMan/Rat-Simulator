using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PenguinScript : MonoBehaviour
{
    public TextMeshPro PenguinTextSetter;
    public static TextMeshPro PenguinText;
    public GameObject SafeZone;

    public Transform ItemSpawner;

    public GameObject LevelUpPrefab;

    public static bool GivenItem = false;

    private void Start()
    {
        PenguinText = PenguinTextSetter;
        PenguinText.gameObject.SetActive(false);
    }

    //When Penguin is interacted with, send a quick message to tool tips script to help player.
    public static void PenguinInteracted()
    {
        PenguinText.gameObject.SetActive(true);
        ToolTips.StartQuickMessage("Give 1 food to Penguin?");

        //Debug.Log(ToolTips.StaticText.text);

        //If player interacts with penguin while give food tooltip is visable, start the giving interaction event
        if (ToolTips.StaticText.text == "Give 1 food to Penguin?")
        {
            Interaction.NPCInteract("Penguin");
        }
    }

    static bool GaveFoodBool = false;   

    //If give food is true, stop the quickmessage and play the coroutine
    public static void GaveFood()
    {
        Debug.Log("GaveFoodStarted");
        ToolTips.StartQuickMessage(null);
        GaveFoodBool = true;
    }
    private void Update()
    {
        Debug.Log(GaveFoodBool);

        if (GaveFoodBool == true)
        {
            StopAllCoroutines();
            StartCoroutine(PenguinFetchAnimation());
            GaveFoodBool = false;
        }
    }

    //Plays the animation, text and giving of the item.
    IEnumerator PenguinFetchAnimation()
    {
        GivenItem = true;
        //Debug.Log("StartedFetch");
        PenguinText.text = "Thanks. BRB.";
        yield return new WaitForSeconds(4);
        PenguinText.text = "Here you go.";
        //Debug.Log("Waited and Spawned");
        Instantiate(LevelUpPrefab, ItemSpawner.position, ItemSpawner.rotation);
        yield return new WaitForSeconds(1.5f);
        PenguinText.gameObject.SetActive(false);
    }
}
