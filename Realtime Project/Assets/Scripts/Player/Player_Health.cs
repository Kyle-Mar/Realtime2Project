using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : Health, IDamageable
{
    public override void Die()
    {
        Physics.gravity = new Vector3(0, -9.8f);
        SceneManager.LoadScene("DeathScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // This can be used for calling the base class's die method.
        // base.Die();
    }
}
