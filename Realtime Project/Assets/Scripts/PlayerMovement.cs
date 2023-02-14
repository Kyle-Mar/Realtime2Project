using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Cam;
    public PlayerAttack Attack;
    // We use a PlayerBody to separate the player from the Player's Body which has the camera.
    public GameObject PlayerBody;
    [Range(1f, 10f)]
    public float MoveSpeed = 1;


    Rigidbody rb;
    float xRot = 0f;
    float yRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Aim(Vector2 input)
    {
        // It's flipped. Trust me.
        //Debug.Log("AIMING");
        if(Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        yRot += input[0];
        xRot -= input[1];
        
        // Prevent the player from breaking their neck.
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Only Change the specific values.
        Cam.transform.localRotation = Quaternion.Euler(xRot, Cam.transform.rotation.y, Cam.transform.rotation.z);
        PlayerBody.transform.localRotation = Quaternion.Euler(PlayerBody.transform.rotation.x, yRot, PlayerBody.transform.rotation.z);
    }

    public void Move(Vector2 input)
    {
        Vector3 moveVector = Vector3.zero;
        
        moveVector += input[0] * PlayerBody.transform.right;
        moveVector += input[1] * PlayerBody.transform.forward;

        // So the player can't move faster by moving diagonally.
        moveVector.Normalize();
        moveVector *= MoveSpeed;

        // Don't ignore gravity
        moveVector.y = rb.velocity.y;
        rb.velocity = moveVector;
    }
}