using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterConsole : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public delegate void GravityEventHandler(Quaternion angle);
    public static event GravityEventHandler OnGravityFlip;

    public Transform PlayerBodyTransform;

    void Start()
    {
        PlayerBodyTransform = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // NOTE: THIS WILL CHANGE. WE WILL NEED TO OPEN A MENU TOO LATER DOWN THE LINE.
    public void Interact()
    {
        Physics.gravity *= -1;
        Quaternion quat = Quaternion.AngleAxis(180, PlayerBodyTransform.forward);
        OnGravityFlip?.Invoke(quat);
    }
}
