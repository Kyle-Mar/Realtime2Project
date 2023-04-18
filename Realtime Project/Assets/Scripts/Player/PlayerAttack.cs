using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
     
    public Collider HurtBox;
    public float AttackCooldown;
    public float AttackLength;
    public float AttackDamage;
    public float KnockbackStrength;
    public float KnockbackUpward;
    public bool isAttacking;

    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("PlayerBody");
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
        if (other.gameObject.CompareTag("Terminal"))
        {
            return;
        }
        other.gameObject.GetComponent<IDamageable>()?.Damage(AttackDamage);
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            
            Vector3 knockbackVector = camera.transform.forward;

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(knockbackVector.x, 0, knockbackVector.z).normalized  * KnockbackStrength);

            print(Physics.gravity.y);
             
            float vertForce;
            if (Physics.gravity.y < 0)
            {
                vertForce = KnockbackUpward;
            }
            else
            {
                vertForce = -KnockbackUpward;
            }

            rb.AddForce(Vector3.up * vertForce);

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
