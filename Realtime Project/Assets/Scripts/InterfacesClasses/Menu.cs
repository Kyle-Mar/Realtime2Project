using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }
    public GameObject menuObject;

    public virtual void OnOpen()
    {
        ;
    }
    public virtual void OnClose()
    {
        ;
    }
}
