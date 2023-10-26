using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeartSystemManager : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Sigleton
    private static HeartSystemManager instance;
    public static HeartSystemManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<HeartSystemManager>();
            return instance;
        }
    }
    #endregion

    public static bool GameStateMaster;
    public static float health;
    public float currenthealth;

    public float maxHealth;
    public float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }


    //Heals player by value
    public void Heal(float healed)
    {
        health += healed;
        ClampHealth();
    }

    //Hurts player by value
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    //Sets defaults on scene opening
    public void Awake()
    {
        maxHealth = 3;
        health = 3;
        currenthealth = 3;
    }


    public void FixedUpdate()
    {
        //If visable is not the same as current health, update visuals and make them the same
        if (currenthealth != health)
        {
            ClampHealth();
        }
        currenthealth = health;

        //Checks if player is dead
        if (health == 0)
        {
            Debug.Log("Game over");
            GameOverviewer.GameOver = true;
            GameStateMaster = false;
        }
    }

    //Checks that health can't go above max health
    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    //Updates visuals of hearts
    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
