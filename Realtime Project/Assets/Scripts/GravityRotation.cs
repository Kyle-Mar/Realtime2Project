using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion futureRotation;

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
        if (futureRotation != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, futureRotation, Mathf.Clamp(3f * Time.deltaTime, 0, 1));
        }
    }

    void RotateWithGravity(Quaternion quat)
    {
        futureRotation = transform.rotation * quat;
    }
}
