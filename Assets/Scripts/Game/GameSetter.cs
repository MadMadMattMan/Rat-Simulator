using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameSetter : MonoBehaviour
{
    public float GlobalLightIntensity;
    public GameObject GlobalLight;

    public float TimeScale;

    private void Awake()
    {
        GlobalLight.GetComponent<Light2D>().intensity = GlobalLightIntensity;
        TimeScale = 1;
    }

    private void Update()
    {
        Time.timeScale = TimeScale;
    }
}
