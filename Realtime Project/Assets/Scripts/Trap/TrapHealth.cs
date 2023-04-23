using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHealth : Health
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(base.health);
        
    }

    public override void Die()
    {
        gameObject.GetComponent<TrapBehavior>().tile.isFree = true;
        base.Die();
    }
}
