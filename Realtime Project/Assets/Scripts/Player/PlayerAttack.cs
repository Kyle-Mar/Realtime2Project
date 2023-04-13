using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider HurtBox;
    public float AttackCooldown = .5f;
    public float AttackLength = .1f;
    public float AttackDamage = 50f;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        if (HurtBox == null)
        {
            Debug.LogError("Unresolved Reference PlayerAttack.cs");
        }
        HurtBox.enabled = false;
    }

    public void Attack()
    {
        if (isAttacking)
        {
            return;
        }
        HurtBox.enabled = true;
        StartCoroutine(AttackTimer());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terminal") || other.gameObject.CompareTag("Trap"))
        {
            return;
        }
        if (HurtBox.enabled)
        {
            other.gameObject.GetComponent<IDamageable>()?.Damage(AttackDamage);
        }
    }

    IEnumerator AttackTimer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(AttackLength);
        HurtBox.enabled = false;
        yield return new WaitForSeconds(AttackCooldown - AttackLength);
        isAttacking = false;
    }
}   
