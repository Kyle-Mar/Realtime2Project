using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    // Start is called before the first frame update
    void Start()
    {
        Pause();
        Unpause();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Tab))
        #else
        if (Input.GetKeyDown(KeyCode.Escape))
        #endif
        if (IsActive)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        MenuManager.OpenMenu(this);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        MenuManager.CloseMenu(this);
        Time.timeScale = 1;
    }
}
