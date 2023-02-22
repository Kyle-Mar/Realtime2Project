using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected const float MAX_HEALTH = 100f;
    [SerializeField]
    protected float health = MAX_HEALTH;
    public virtual void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
