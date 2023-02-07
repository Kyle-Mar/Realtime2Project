using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider hurtBox;
    // Start is called before the first frame update
    void Start()
    {
        if (hurtBox == null)
        {
            Debug.LogError("Unresolved Reference PlayerAttack.cs");
        }
        hurtBox.enabled = false;
    }

    public void Attack()
    {
        hurtBox.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IDamageable>()?.Damage(10f);
    }

}
