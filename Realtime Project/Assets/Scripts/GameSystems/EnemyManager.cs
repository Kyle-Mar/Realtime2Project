using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> towerList = new List<GameObject>();
    public List<GameObject> slimeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject slime in slimeList)
        {
            if (slime != null)
            {
                foreach (GameObject tower in towerList)
                {
                    if (Vector3.Distance(tower.transform.position, slime.transform.position) < 10)
                    {
                        EnemyAI slimeScript = slime.GetComponent<EnemyAI>();
                        //slimeScript.pointOfFocus = tower;
                    }
                    else
                    {
                        EnemyAI slimeScript = slime.GetComponent<EnemyAI>();
                        //slimeScript.pointOfFocus = null;
                    }
                }
            }
        }
    }

    public void AddTower(GameObject newTower)
    {
        towerList.Add(newTower);
    }

    public void RemoveSlime(GameObject slime)
    {
        slimeList.Remove(slime);
    }

    public void ResetOnDeath()
    {
        towerList.Clear();
        slimeList.Clear();
    }

}
