using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleHealth : MonoBehaviour, IDamageable
{
    public const float MAX_HEALTH = 100f;
    float health = MAX_HEALTH;
    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
