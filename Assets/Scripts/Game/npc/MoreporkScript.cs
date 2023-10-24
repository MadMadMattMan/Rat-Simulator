using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoreporkScript : MonoBehaviour
{
    public TextMeshPro MoreporkTextSetter;
    public static TextMeshPro MoreporkText;

    public Transform ItemSpawner;

    public GameObject LevelUpPrefab;

    public static bool GivenItem = false;

    private void Start()
    {
        MoreporkText = MoreporkTextSetter;
        MoreporkText.gameObject.SetActive(false);
    }

    //When Morepork is interacted with, send a quick message to tool tips script to help player.
    public static void MoreporkInteracted()
    {
        MoreporkText.gameObject.SetActive(true);
        ToolTips.StartQuickMessage("Give 1 food to Morepork?");

        //Debug.Log(ToolTips.StaticText.text);

        //If player interacts with morepork while give food tooltip is visable, start the giving interaction event
        if (ToolTips.StaticText.text == "Give 1 food to Morepork?")
        {
            Interaction.NPCInteract("Morepork");
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
            StartCoroutine(MoreporkFetchAnimation());
            GaveFoodBool = false;
        }
    }

    //Plays the animation, text and giving of the item.
    IEnumerator MoreporkFetchAnimation()
    {
        GivenItem = true;
        //Debug.Log("StartedFetch");
        MoreporkText.text = "Thanks. BRB.";
        yield return new WaitForSeconds(4);
        MoreporkText.text = "Here you go.";
        //Debug.Log("Waited and Spawned");
        Instantiate(LevelUpPrefab, ItemSpawner.position, ItemSpawner.rotation);
        yield return new WaitForSeconds(1.5f);
        MoreporkText.gameObject.SetActive(false);
    }
}

