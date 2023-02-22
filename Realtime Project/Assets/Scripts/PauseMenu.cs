using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    static bool isPaused = false;
    public static bool IsPaused { get => isPaused; set => isPaused = value; }
    public GameObject menu;

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
        if (isPaused)
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
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void Unpause()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
