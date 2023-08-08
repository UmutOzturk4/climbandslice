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
    public Text text;

    GameObject[] floorsInScene;
    public GameObject[] floors;
    int randomnmr, lastrandom = 0;
    public int platformcount;
    Vector3 pos = new Vector3(-14,0,0);
    Vector3 increasePos = new Vector3(0, 2.5f, 0);
    public GameObject[] enemies;
    GameObject[] spawnPointsinScene;
    public int levelCount;
    int enemycount;
    public int frequency;
    int enemyeuler = 90;
    void Start()
    {
        
        /* if (PlayerPrefs.GetInt("platformcount") == 0) 
         {
             PlayerPrefs.SetInt("platformcount",1);
         }*/
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
        instantieenemy();
        if (levelCount % 10 == 0)
        {
            InstantiateBoss();
        }
    }
    private void Update()
    {
        //text.text = "" + PlayerPrefs.GetInt("levelcount") + "  " + levelCount + "          " + PlayerPrefs.GetInt("platformcount") + "         " + platformcount;
       /* if (levelCount % 10 == 0 )
        {
            PlayerPrefs.SetInt("frequency",frequency);
        }*/
    }
    public void instantieenemy()
    {
        spawnPointsinScene = GameObject.FindGameObjectsWithTag("enemySpawnPoint");
        GameObject firstEnemy = Instantiate(enemies[0], spawnPointsinScene[0].transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));
        enemycount++;
        for (int i = spawnPointsinScene.Length; i > 0; i--)
        {
            if (i % frequency == 0)
            {
                enemycount++;
                GameObject enemy = Instantiate(enemies[0], spawnPointsinScene[i-1].transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, enemyeuler, 0));              
            }
        }
    }
    public void InstantiateBoss()
    {
        Instantiate(floors[0], pos + increasePos, Quaternion.identity);
    }
}
