using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConsoleHealth : MonoBehaviour, IDamageable
{
    public float MAX_HEALTH { get; set; } = 100f;

    public float health { get; set; }
    static float trueHealth;
    static GameObject[] terminals;

    public void Awake()
    {
        health = MAX_HEALTH;
        trueHealth = MAX_HEALTH;
        terminals = GameObject.FindGameObjectsWithTag("Terminal");
    }

    public void Damage(float amount)
    {
        trueHealth -= amount;

        for (int i = 0; i < terminals.Length; i++)
        {
            terminals[i].gameObject.GetComponent<ConsoleHealth>().health = trueHealth;
        }
        
        if (trueHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
