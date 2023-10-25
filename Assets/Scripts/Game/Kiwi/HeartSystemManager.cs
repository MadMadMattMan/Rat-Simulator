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

    public void Heal(float healed)
    {
        health += healed;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    public void Awake()
    {
        maxHealth = 3;
        health = 3;
        currenthealth = 3;
    }


    public void FixedUpdate()
    {
        if (currenthealth != health)
        {
            ClampHealth();
        }
        currenthealth = health;

        if (health == 0)
        {
            Debug.Log("Game over");
            GameOverviewer.GameOver = true;
            GameStateMaster = false;
        }
    }

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

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
