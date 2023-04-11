using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripParticle : MonoBehaviour
{
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Pause();
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(Random.Range(0f, 5f));
        particleSystem.Play();
    }
}
