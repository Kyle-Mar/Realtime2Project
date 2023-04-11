using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    // Start is called before the first frame update
    // Quaternions are undefined at null.
    Quaternion futureRotation = Quaternion.identity;

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
        //Debug.Log(futureRotation.ToString() + transform.rotation.ToString());
        transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, futureRotation.normalized, 100f * Time.deltaTime);
        
    }

    void RotateWithGravity(Quaternion quat)
    {
        futureRotation = transform.rotation * quat;
    }
}
