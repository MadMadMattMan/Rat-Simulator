using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void AddHealth()
    {
        HeartSystemManager.Instance.AddHealth();
    }

    public void Heal(float health)
    {
        HeartSystemManager.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        HeartSystemManager.Instance.TakeDamage(1);
    }
}
