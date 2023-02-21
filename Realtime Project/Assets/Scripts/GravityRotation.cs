using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion futureRotation = Quaternion.identity;
    float timer;
    void Start()
    {
        CenterConsole.OnGravityFlip += RotateWithGravity;
    }

    private void OnDisable()
    {
        CenterConsole.OnGravityFlip -= RotateWithGravity;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, futureRotation, .5f);
        
    }

    void RotateWithGravity(Quaternion quat)
    {
        futureRotation = transform.rotation * quat;
    }
}
