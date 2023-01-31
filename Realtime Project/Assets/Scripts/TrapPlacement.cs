using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacement : MonoBehaviour
{
    public GameObject PlayerBody;
    public GameObject TeslaTrap;
    public GameObject LaserTrap;
    public GameObject SpikeTrap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = PlayerBody.transform.position;
        Vector3 playerDirection = PlayerBody.transform.forward * 5.0f;
        Vector3 trapLocation = new Vector3((int)(playerPos.x + playerDirection.x), 2.6f, (int)(playerPos.z + playerDirection.z));

        if (Input.GetKeyDown("1"))
        {
            Debug.Log(playerPos);
            Debug.Log(PlayerBody.transform.forward);
            Debug.Log(trapLocation);
            Debug.Log(" ");
            Instantiate(TeslaTrap, trapLocation, Quaternion.Euler(0,0,0));
        }
        else if (Input.GetKeyDown("2"))
        {
            Instantiate(LaserTrap, trapLocation, Quaternion.Euler(0, 0, 0));
        }
        else if (Input.GetKeyDown("3"))
        {
            Instantiate(SpikeTrap, trapLocation, Quaternion.Euler(0, 0, 0));
        }
    }
}
