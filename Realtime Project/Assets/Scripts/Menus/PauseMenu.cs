using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
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

    public override void OnOpen()
    {
        Pause();
        base.OnOpen();
    }

    public override void OnClose()
    {
        Unpause();
        base.OnClose();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
