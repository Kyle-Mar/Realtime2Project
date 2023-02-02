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
        Ray ray = new Ray(PlayerBody.transform.position, PlayerBody.transform.forward);
        RaycastHit hitData;
        bool raycastCheck = Physics.Raycast(ray, out hitData, 4.0f);

        if (raycastCheck && hitData.collider.tag == "TileUnit")
        {
            //Debug.Log("Hit Tile Object");
            GameObject thisTile = hitData.transform.gameObject;
            TileScript tileScript = thisTile.GetComponent<TileScript>();
            if (tileScript.isFree)
            {
                tileScript.lookedAt = true;
                //Debug.Log("Free Tile");

                // Place Trap on Selected Tile
                Vector3 trapLocation = new Vector3(thisTile.transform.position.x, 2.5f, thisTile.transform.position.z); // Only works on ground for now

                if (Input.GetKeyDown("1"))
                {
                    Instantiate(TeslaTrap, trapLocation, Quaternion.Euler(0, 0, 0));
                    tileScript.isFree = false;
                }
                else if (Input.GetKeyDown("2"))
                {
                    Instantiate(LaserTrap, trapLocation, Quaternion.Euler(0, 0, 0));
                    tileScript.isFree = false;
                }
                else if (Input.GetKeyDown("3"))
                {
                    Instantiate(SpikeTrap, trapLocation, Quaternion.Euler(0, 0, 0));
                    tileScript.isFree = false;
                }

            }
        }
        //else Debug.Log("No Hit");




        // Old Code
        /*Vector3 playerPos = PlayerBody.transform.position;
        Vector3 playerDirection = PlayerBody.transform.forward * 5.0f;
        Vector3 trapLocation = new Vector3((int)(playerPos.x + playerDirection.x), 2.6f, (int)(playerPos.z + playerDirection.z));

        if (Input.GetKeyDown("1"))
        {
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
        */
    }

    void EvaluateRay(RaycastHit hitData)
    {
        //
    }

}
