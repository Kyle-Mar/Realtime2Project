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
    public GameObject enemyManager;
    public GameObject hurtbox;
    private float damage = 50.0f;

    public float setDamageTimer = 5.0f;
    private float damageTimer;

    private LineRenderer damageLine;
    private float damageLineRemainTimer = 0.0f;

    public float damageDealt = 0.0f;
    private float maxDamageDealt = 1400.0f;


    void Start()
    {
        damageTimer = 3.0f; // Initial Pause
        

        switch (trapVariant)
        {
            case trapType.Tesla:
                setDamageTimer = 0.2f;
                damage = 25.0f;
                SetDamageLine();
                break;

            case trapType.Laser:
                setDamageTimer = 0.1f;
                damage = 20;
                SetDamageLine();
                break;

            case trapType.Spike:
                setDamageTimer = 1.5f;
                damage = 70.0f;
                damageLine = null;
                break;

            case trapType.Signal:
                setDamageTimer = 100f;
                damage = 0f;
                damageLine = null;
                enemyManager.GetComponent<EnemyManager>().AddTower(gameObject);

                break;
        }
        maxDamageDealt = damage * 15.0f;
    }

    void Update()
    {
        // Deal damage
        damageTimer -= Time.deltaTime;

        if (damageLine != null)
        {
            if (damageLineRemainTimer > 0)
            {
                damageLineRemainTimer -= Time.deltaTime;
            }
            else
            {

                damageLine.enabled = false;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Traps with lasers
        if (trapVariant == trapType.Tesla || trapVariant == trapType.Laser)
        {
            //damageLine.enabled = false;
            if (other.gameObject.CompareTag("Enemy"))
            {
                damageLine.enabled = true;
                if (damageTimer < 0)
                {
                    damageTimer = setDamageTimer;
                    damageLine.SetPosition(1, other.transform.position);
                    damageLineRemainTimer = 0.5f;
                    //Debug.Log("Dealing Damage");
                    other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
                    damageDealt += damage;
                }

            }
        }
        // Traps without lasers
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (damageTimer < 0)
                {
                    damageTimer = setDamageTimer;
                    other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
                    damageDealt += damage;
                }

            }
        }
        
    }

    private void SetDamageLine()
    {
        damageLine = GetComponent<LineRenderer>();
        damageLine.SetPosition(0, transform.position);
        damageLine.SetPosition(1, transform.position);
        damageLine.enabled = false;
    }
}
