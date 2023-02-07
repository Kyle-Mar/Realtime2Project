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
    private SphereCollider hurtbox;

    public GameObject hurtboxDebug;


    void Start()
    {
        hurtbox = GetComponent<SphereCollider>();
        Vector3 newPos = transform.position;
        switch (trapVariant)
        {

            case trapType.Tesla:
                newPos.y = Physics.gravity.y * 10.0f;
                //SetHurtbox(newPos, 4.0f);
                break;
            case trapType.Laser:
                newPos.y = Physics.gravity.y * 10.0f;
                SetHurtbox(newPos, 3.0f);
                break;
            case trapType.Spike:
                SetHurtbox(newPos, 4.0f);
                break;
            default:
                break;
        }
    }

    void Update()
    {

    }

    void SetHurtbox(Vector3 pos, float radius)
    {
        hurtbox.transform.position = pos;
        hurtbox.radius = radius;

        hurtboxDebug.transform.position = pos;
        hurtboxDebug.transform.localScale = new Vector3(radius, radius, radius);    
    }
}
