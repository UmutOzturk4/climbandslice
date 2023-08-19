using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateFloor : MonoBehaviour
{
    GameObject[] spawnPointsinScene;
    public GameObject lastfloor;
    public GameObject[] floors;
    public GameObject[] enemies;
    public GameObject boss;

    int randomenemy;
    public int platformcount;
    public int frequency;
    public int levelCount;
    int randomnmr, lastrandom = 0;
    int enemyeuler = 90;

    Vector3 pos = new (-14,0,0);
    Vector3 increasePos = new (0, 2.5f, 0);

    void Start()
    {
        if (PlayerPrefs.GetInt("platformcount") == 0) 
         {
            PlayerPrefs.SetInt("platformcount",1);
            PlayerPrefs.SetInt("frequency", 4);

         }
        frequency = PlayerPrefs.GetInt("frequency");
        platformcount = PlayerPrefs.GetInt("platformcount");
        levelCount = PlayerPrefs.GetInt("levelcount");
        Instantiate(floors[0],pos,Quaternion.Euler(90,0,0));           
        for (int i = 0; i < PlayerPrefs.GetInt("platformcount"); i++)
        {
            randomnmr = Random.Range(1, 4);
            if (lastrandom != randomnmr)
            {
                Instantiate(floors[randomnmr], pos + increasePos, Quaternion.identity);
                increasePos += new Vector3(0, 3f, 0);
            }
            else
            {
                i--;
            }
            lastrandom = randomnmr;
        }
        Instantieenemy();
        if (levelCount % 10 == 0)
        {
            InstantiateBoss();
        }
    }
    public void Instantieenemy()
    {
        randomenemy = Random.Range(0,2);
        spawnPointsinScene = GameObject.FindGameObjectsWithTag("enemySpawnPoint");
        GameObject firstEnemy = Instantiate(enemies[randomenemy], spawnPointsinScene[0].transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));
        for (int i = spawnPointsinScene.Length; i > 0; i--)
        {
            if (i % frequency == 0)
            {
                GameObject enemy = Instantiate(enemies[randomenemy], spawnPointsinScene[i-1].transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));              
                randomenemy= Random.Range(0, 2);
            }
        }
    }
    public void InstantiateBoss()
    {
        Instantiate(lastfloor, pos + increasePos + new Vector3(-3.5f,0,0), Quaternion.Euler(90, 0, 0));
        GameObject enemy = Instantiate(boss, GameObject.FindGameObjectWithTag("lastfloor").transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));
        //Instantiate(boss, GameObject.FindGameObjectWithTag("mainfloor").transform.position, Quaternion.Euler(0, enemyeuler, 0)) ;
    }
}
