using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameSetter : MonoBehaviour
{
    public float GlobalLightIntensity;
    public float GlobalDaylight;
    public GameObject GlobalLight;

    public float TimeScale;

    //Sets game scene aspects to default - light and time
    private void Awake()
    {
        HeartSystemManager.GameStateMaster = true;
        GlobalLight.GetComponent<Light2D>().intensity = GlobalLightIntensity;
        TimeScale = 1;
    }
}
