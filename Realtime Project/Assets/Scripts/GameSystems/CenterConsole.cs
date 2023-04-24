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
    static Vector3 rotAxis = new Vector3(0, 0, 0);
    bool isFlippable = true;
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

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * PlayerInputController.CurrentSensitivity;
        yRot += mouseInput[0];
        rotAxis = Quaternion.Euler(init.x, yRot, init.z) * init;
    }
    
    public void Interact()
    {
        if (!isFlippable)
        {
            return;
        }
        Debug.Log("HELLo");
        //StartCoroutine(GravityCooldown());
        MenuManager.OpenMenu(MenuManager.ConsoleMenu);
    }

    // this should be moved to the console menu script but, time crunch lol.
    public static void FlipGravity()
    {
        Physics.gravity *= -1;
        Quaternion quat = Quaternion.AngleAxis(180, rotAxis);
        OnGravityFlip?.Invoke(quat);
    }

    IEnumerator GravityCooldown()
    {
        isFlippable = false;
        yield return new WaitForSeconds(1.5f);
        isFlippable = true;
    }

}
