using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleHealth : Health, IDamageable
{
    static float trueHealth;
    static GameObject[] terminals;

    public void Awake()
    {
        health = MAX_HEALTH;
        trueHealth = MAX_HEALTH;
        terminals = GameObject.FindGameObjectsWithTag("Terminal");
    }

    public void Damage(float amount)
    {
        base.Damage(amount);
        trueHealth = base.health

        for (int i = 0; i < terminals.Length; i++)
        {
            terminals[i].gameObject.GetComponent<ConsoleHealth>().health = trueHealth;
        }
    }
    public override void Die()
    {
        Physics.gravity = new Vector3(0, -9.8f);
        SceneManager.LoadScene("DeathScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
