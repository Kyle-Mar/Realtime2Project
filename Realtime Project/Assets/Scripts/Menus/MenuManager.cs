using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager :MonoBehaviour
{
    static bool isInitialized { get; set; } = false;



    private static ConsoleMenu consoleMenu;
    private static PauseMenu pauseMenu;
    private static Menu activeMenu;



    public static ConsoleMenu ConsoleMenu { get
        {
            if (!isInitialized)
            {
                Init();
            }
            return consoleMenu;
        } 
    }
    public static PauseMenu PauseMenu
    {
        get
        {
            if (!isInitialized)
            {
                Debug.Log("NOT INITIALIZED");
                Init();
            }
            //Debug.Log(pauseMenu);
            return pauseMenu;
        }
    }
    public static Menu ActiveMenu
    {
        get
        {
            if (!isInitialized)
            {
                Init();
            }
            return activeMenu;
        }
    }

    public static void Init()
    {
        GameObject menuContainer = GameObject.Find("CurrentMenu");
        pauseMenu = menuContainer.GetComponent<PauseMenu>();
        //consoleMenu = menuContainer.transform.Find("ConsoleMenu").GetComponent<ConsoleMenu>();
        isInitialized = true;

    }

    public static void OpenMenu(Menu menu)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (activeMenu != null)
        {
            activeMenu.IsActive = false;
        }
        menu.IsActive = true;
        activeMenu = menu;
    }
}
