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
            // for some reason, re-loading the scene doesn't reset the gravity.
            // it might be worth it in the future in whatever game manager script we
            // end up using, to subscribe to the on scene changed event and reset the gravity there.
            // this fixes that.
            Physics.gravity = new Vector3(0, -9.8f);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
