using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacement : MonoBehaviour
{
    public GameObject EnemyManager;
    public GameObject PlayerBody;
    

    public GameObject TeslaTrap;
    public GameObject LaserTrap;
    public GameObject SpikeTrap;
    public GameObject SignalTrap;
    public PlayerInventory playerInventory;

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
                //Vector3 trapLocation = new Vector3(thisTile.transform.position.x, 2.5f, thisTile.transform.position.z); // Only works on ground for now
                Vector3 trapLocation = tileScript.spawnPos.transform.position;

                if (Input.GetKeyDown("1"))
                {
                    RemoveItemResult itemAndSuccess = playerInventory.RemoveItem(0);
                    if (itemAndSuccess.Success)
                    {
                        CreateTrap(itemAndSuccess.Item.obj, trapLocation, tileScript);
                    }
                }
                else if (Input.GetKeyDown("2"))
                {
                    RemoveItemResult itemAndSuccess = playerInventory.RemoveItem(1);
                    if (itemAndSuccess.Success)
                    {
                        CreateTrap(itemAndSuccess.Item.obj, trapLocation, tileScript);
                    }
                }
                else if (Input.GetKeyDown("3"))
                {
                    RemoveItemResult itemAndSuccess = playerInventory.RemoveItem(2);
                    if (itemAndSuccess.Success)
                    {
                        CreateTrap(itemAndSuccess.Item.obj, trapLocation, tileScript);
                    }
                }
                else if (Input.GetKeyDown("4"))
                {
                    //RemoveItemResult itemAndSuccess = playerInventory.RemoveItem(2);
                    //if (itemAndSuccess.Success)
                    {
                        CreateTrap(SignalTrap, trapLocation, tileScript);
                    }
                }
            }
        }
    }

    void CreateTrap(GameObject obj, Vector3 trapLocation, TileScript tileScript)
    {
        float upDirection = 0.0f;
        if (Physics.gravity.y > 0.0f)
        {
            upDirection = 180.0f;
        }


        GameObject spawnedTrap = Instantiate(obj, trapLocation, Quaternion.Euler(upDirection, 0, 0));
        TrapBehavior trapBehavior = spawnedTrap.GetComponent<TrapBehavior>();
        trapBehavior.enemyManager = EnemyManager;
        //trapBehavior.tile = tileScript;
        tileScript.isFree = false;
    }

    void EvaluateRay(RaycastHit hitData)
    {
        //
    }

}
