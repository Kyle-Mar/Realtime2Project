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

    public float setDamageTimer = 5.0f;
    private float damageTimer;
    //private bool dealDamage = false;

    public int numTargetsTotal = 10;
    private int numTargetsHit = 0;


    void Start()
    {
        damageTimer = setDamageTimer;
    }

    void Update()
    {
        // Deal damage
        damageTimer -= Time.deltaTime;
        /*
        if (damageTimer < 0)
        {
            dealDamage = true;
            damageTimer = setDamageTimer;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        // If able to hit more enemies
        if (numTargetsHit < numTargetsTotal)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (damageTimer < 0)
                {
                    //dealDamage = true;
                    damageTimer = setDamageTimer;
                    other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
                }

                // OLD CODE PLEASE IGNORE

                //Debug.Log("Dealing Damage");
                /*switch (trapVariant)
                {
                    case trapType.Tesla:
                        {
                            // Zap three enemies every pulse
                            if (damageTimer < 0)
                            {
                                //dealDamage = true;
                                damageTimer = setDamageTimer;
                                other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
                            }
                            break;
                        }
                    case trapType.Laser:
                        {

                            break;
                        }
                    case trapType.Spike:
                        {

                            break;
                        }
                }*/

            }
        }
    }
}
