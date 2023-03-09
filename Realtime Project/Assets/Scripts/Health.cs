using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    public float MAX_HEALTH { get; } = 100f;
    public float health { get; set; }
    public virtual void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    
    void Awake()
    {
        health = MAX_HEALTH;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
