using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Cam;
    // We use a PlayerBody to separate the player from the Player's Body which has the camera.
    public GameObject PlayerBody;
    [Range(1f, 10f)]
    public float MouseSensitivity = 1;
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

    // Update is called once per frame
    void Update()
    {
        Aim();
        Move();
    }

    void Aim()
    {
        // It's flipped. Trust me.
        
        yRot += Input.GetAxis("Mouse X") * MouseSensitivity;
        xRot -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        
        // Prevent the player from breaking their neck.
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Only Change the specific values.
        Cam.transform.localRotation = Quaternion.Euler(xRot, Cam.transform.rotation.y, Cam.transform.rotation.z);
        PlayerBody.transform.localRotation = Quaternion.Euler(PlayerBody.transform.rotation.x, yRot, PlayerBody.transform.rotation.z);
    }

    void Move()
    {
        Vector3 moveVector = Vector3.zero;
        
        // Raw input. Otherwise Axis output is smoothed.
        moveVector += Input.GetAxisRaw("Horizontal") * PlayerBody.transform.right;
        moveVector += Input.GetAxisRaw("Vertical") * PlayerBody.transform.forward;

        // So the player can't move faster by moving diagonally.
        moveVector.Normalize();
        moveVector = moveVector * MoveSpeed;

        // Don't ignore gravity
        moveVector.y = rb.velocity.y;
        rb.velocity = moveVector;
    }
}