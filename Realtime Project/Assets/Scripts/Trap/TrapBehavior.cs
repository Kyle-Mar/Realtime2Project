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
    private float timer;
    private bool dealDamage = false;


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
            dealDamage = true;
            timer = setDamageTimer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Dealing Damage");
            other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
        }
    }
}
