using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrapItem : ScriptableObject
{
    public string itemName;
    public float cost;
    public Sprite image;
    public GameObject obj;
}
