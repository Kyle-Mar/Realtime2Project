using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [Range(10.0f, 100f)]
    public float RotationSpeed = 10f;
    [Range(0.1f, 10f)]
    public float HoverSpeed = 10f;
    [Range(0.1f, 10f)]
    public float HoverHeight = 10f;
    private Vector3 StartPosition;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(StartPosition, playerObject.transform.position);
        if (distanceToPlayer < 3.0f)
        {
            StartPosition = Vector3.MoveTowards(StartPosition, playerObject.transform.position, Time.deltaTime);
        }
        transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime));
        transform.position = StartPosition + new Vector3(0, HoverHeight * Mathf.Sin(Time.time * HoverSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.numCoins++;
            Destroy(gameObject);
        }
    }
}
