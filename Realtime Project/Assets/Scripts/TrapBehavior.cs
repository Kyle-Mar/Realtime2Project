using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public enum trapType
    {
        Tesla,
        Laser,
        Spike
    }

    public trapType trapVariant;
    public GameObject hurtbox;
    public float damage = 1.0f;

    public float setDamageTimer;
    private float timer;


    void Start()
    {
        timer = setDamageTimer;
    }

    void Update()
    {
        // Deal damage
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            dealDamage();
        }
    }

    void dealDamage()
    {

    }
}
