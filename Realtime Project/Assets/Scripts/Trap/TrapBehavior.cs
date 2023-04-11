using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public enum trapType
    {
        Tesla,
        Laser,
        Spike,
        Signal
    }

    public trapType trapVariant;
    public GameObject hurtbox;
    private float damage = 50.0f;
    public TileScript tile;

    public float setDamageTimer = 5.0f;
    private float damageTimer;


    void Start()
    {
        damageTimer = 3.0f; // Initial Pause
        switch (trapVariant)
        {
            case trapType.Tesla:
                setDamageTimer = 0.2f;
                damage = 25.0f;
                break;
            case trapType.Laser:
                setDamageTimer = 0.1f;
                damage = 20;
                break;
            case trapType.Spike:
                setDamageTimer = 1.5f;
                damage = 70.0f;
                break;
            case trapType.Signal:
                setDamageTimer = 100;
                damage = 0;
                break;
        }
    }
    void Update()
    {
        // Deal damage
        damageTimer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (damageTimer < 0)
            {
                damageTimer = setDamageTimer;

                //Debug.Log("Dealing Damage");
                other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
            }
            
        }
    }
}
