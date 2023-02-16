using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public float moveSpeed = 3f;
    public float aggroRange = 30f;

    public GameObject player;
    public GameObject controlPanel;

    private GameObject moveTarget;

    private Vector3 targetPosition;

    private bool isGrounded = false;
    private bool isAggro = false;

    public const float MAX_HEALTH = 100f;
    float health = MAX_HEALTH;

    public const float STRENGTH = 1.0f;
    IDamageable playerDamageScript;

    void Start()
    {
        if(controlPanel == null || player == null)
        {
            Debug.LogError("Unresolved Reference in EnemyAi.cs");
        }
        playerDamageScript= player.GetComponent<IDamageable>();

        moveTarget = controlPanel;
        targetPosition = new Vector3(
            moveTarget.transform.position.x,
            transform.position.y,
            moveTarget.transform.position.z
            );
        transform.LookAt(targetPosition, Vector3.up * -Mathf.Sign(Physics.gravity.y));
    }

    void Update()
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
        transform.LookAt(targetPosition, Vector3.up * -Mathf.Sign(Physics.gravity.y));
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded= true;
        }
        //Vector3 direction = Vector3.up * Mathf.Sign(Physics.gravity.magnitude);
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject == player)
        {
            playerDamageScript.Damage(STRENGTH);
        }
    }
}
