using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConsoleHealth : Health
{
    public override void Die()
    {
        Physics.gravity = new Vector3(0, -9.8f);
        SceneManager.LoadScene("DeathScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
