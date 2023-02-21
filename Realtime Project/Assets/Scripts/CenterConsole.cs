using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterConsole : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public delegate void GravityEventHandler(Quaternion angle);
    public static event GravityEventHandler OnGravityFlip;

    public Transform PlayerBodyTransform;
    Vector3 init = new Vector3(0,0,0);
    float yRot = 0;

    void Start()
    {
        PlayerBodyTransform = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        init = PlayerBodyTransform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 1;

        yRot += mouseInput[0] * 1;
        init = Quaternion.Euler(init.x, yRot, init.z) * init;

    }
    
    // NOTE: THIS WILL CHANGE. WE WILL NEED TO OPEN A MENU TOO LATER DOWN THE LINE.
    public void Interact()
    {
        Physics.gravity *= -1;
        Quaternion quat = Quaternion.AngleAxis(180, init);
        OnGravityFlip?.Invoke(quat);
    }
}
