using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMenu : Menu
{
    // Start is called before the first frame update
    void Start()
    {
        MenuManager.CloseMenu(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipGravity()
    {
        CenterConsole.FlipGravity();
        MenuManager.CloseMenu(this);
    }
}
