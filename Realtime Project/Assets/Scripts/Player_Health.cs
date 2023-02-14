using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour , IDamageable
{
    public const float MAX_HEALTH = 10f;
    float health = MAX_HEALTH;

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
