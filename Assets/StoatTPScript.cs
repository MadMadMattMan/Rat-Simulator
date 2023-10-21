using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoatTPScript : MonoBehaviour
{
    public GameObject StoatSetter;
    public static Transform Stoat;
    public GameObject PenguinBlocker;
    public GameObject MoreporkBlocker;
    static string CollisionObject = null;

    private void Start()
    {
        Stoat = StoatSetter.transform;
    }


    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "Penguin Safe Zone")
        {
            CollisionObject = "Penguin";
        }

        if (trigger.gameObject.name == "MoreporkSafeZone")
        {
            CollisionObject = "Morepork";
        }
    }
    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "Penguin Safe Zone" || trigger.gameObject.name == "Morepork Safe Zone")
        {
            CollisionObject = null;
        }
    }

    public static void SafeZone(string Animal)
    {
        Debug.Log("Recived SafeZone Call");
        Debug.Log(Animal);
        if (CollisionObject == "Penguin" && Animal == "Penguin")
        {
            Debug.Log("TPed Stoat");
            Stoat.position = new Vector3(Stoat.position.x - 15, Stoat.position.y - 3, 0);
        }
    }
}
