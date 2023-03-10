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
                Debug.Log("TEST");
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
        consoleMenu = menuContainer.GetComponent<ConsoleMenu>();
        isInitialized = true;

    }

    public static void OpenMenu(Menu menu)
    {
        if (activeMenu != null)
        {
            CloseMenu(activeMenu);
        }
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menu.IsActive = true;
        activeMenu = menu;
        activeMenu.menuObject.SetActive(true);
    }

    public static void CloseMenu(Menu menu)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.IsActive = false;
        menu.menuObject.SetActive(false);
    }
}
