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


    void Start()
    {

    }

    void Update()
    {

    }
}
