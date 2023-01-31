using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float aggroRange = 30f;

    private GameObject player;
    private GameObject controlPanel;
    private GameObject moveTarget;

    private Vector3 targetPosition;

    private bool isGrounded = false;
    private bool isAggro = false;
    void Start()
    {
        controlPanel = GameObject.Find("Control Panel");
        player = GameObject.Find("Player");
        moveTarget = controlPanel;
    }

    void FixedUpdate()
    {
        if(isAggro)
        {
            if(Vector3.Distance(transform.position, player.transform.position) > aggroRange)
            {
                moveTarget = controlPanel;
                isAggro = false;
            }
        }
        else if(Vector3.Distance(transform.position, player.transform.position) < aggroRange)
        {
            moveTarget = player;
            isAggro = true;
        }
        
        if(isGrounded)
        {
            Move();
        }
    }

    void Move()
    {
        targetPosition= new Vector3(
            moveTarget.transform.position.x,
            transform.position.y, 
            moveTarget.transform.position.z
            );
        transform.LookAt(targetPosition, Vector3.up);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded= true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
