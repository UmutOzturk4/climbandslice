using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class InstantiateFloor : MonoBehaviour
{
    public GameObject[] floors;
    int randomnmr,lastrandom=0,platformcount=10;
    Vector3 pos = new Vector3(-14,0,0);
    Vector3 increasePos = new Vector3(0, 2.5f, 0);
    public GameObject[] enemies;
    GameObject[] spawnPointsinScene;
    int enemycount;
    int enemyeuler = 90;
    void Start()
    {
        Instantiate(floors[0],pos,Quaternion.Euler(90,0,0));           
        for (int i = 0; i < platformcount; i++)
        {
            randomnmr = Random.Range(1, 4);
            if (lastrandom != randomnmr)
            {
                Instantiate(floors[randomnmr], pos + increasePos, Quaternion.identity);
                increasePos += new Vector3(0, 3f, 0);
            }
            lastrandom = randomnmr;
        }
        instantieenemy();
        
    }
    public void instantieenemy()
    {
        spawnPointsinScene = GameObject.FindGameObjectsWithTag("enemySpawnPoint");
        for (int i = 0; i < spawnPointsinScene.Length; i++)
        {
            if (i % 3 == 0)
            {
                enemycount++;
                GameObject enemy = Instantiate(enemies[0], spawnPointsinScene[i].transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));              
            }
        }
    }
}
