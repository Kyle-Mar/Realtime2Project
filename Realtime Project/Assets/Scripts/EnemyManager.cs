using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public List<GameObject> signalTowerListA = new List<GameObject>();
    EnemyAI[] childArray;
    int towerListLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        childArray = GetComponentsInChildren<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        // New tower just dropped
        if (signalTowerListA.Count() > towerListLength)
        {
            Debug.Log(childArray.Length);
            foreach (EnemyAI enemy in childArray) 
            {
                enemy.signalTowerList.Add(signalTowerListA.Last().transform.position);
            }
            towerListLength++;
        }

        // New slime just dropped
    }

    /*public void AddSlime(GameObject newEnemy)
    {
        //GameObject newEnemy = Instantiate(slimeVariant, pos, rot, transform);
        foreach (GameObject signalTower in signalTowerList)
        {
            newEnemy.GetComponent<EnemyAI>().signalTowerList.Add(signalTower.transform.position);
        }
        Debug.Log("GOT HERE !!!!!!!!!!!!!!!!");
    }*/

    public void AddSlime(List<Vector3> enemySignalTowerList)
    {
        //GameObject newEnemy = Instantiate(slimeVariant, pos, rot, transform);
        foreach (GameObject signalTower in signalTowerListA)
        {
           enemySignalTowerList.Add(signalTower.transform.position);
        }
    }
}
