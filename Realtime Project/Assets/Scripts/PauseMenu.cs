using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;


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
        {
        isPaused = !isPaused;
            if (isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

    }

    void Unpause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}
