using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterConsole : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public delegate void GravityEventHandler();
    public static event GravityEventHandler OnGravityFlip;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // NOTE: THIS WILL CHANGE. WE WILL NEED TO OPEN A MENU TOO LATER DOWN THE LINE.
    public void Interact()
    {
        Physics.gravity *= -1;
        OnGravityFlip?.Invoke();
    }
}
