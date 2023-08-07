using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartControl : MonoBehaviour
{
    GameObject[] enemiesInScene;

    public bool gameEnded=false;
    bool invoked = false;
    public GameObject movementui;
    public GameObject nextlvlui;
    InstantiateFloor go;
    private void Start()
    {
        go = this.gameObject.GetComponent<InstantiateFloor>();
        
    }
    void Update()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("enemy");
        if (enemiesInScene.Length == 0 && !invoked)
        {
            invoked = true;
            Invoke("Restart", 1);
        }
    }
    public void Restart()
    {    
        if (go.levelCount % 2 == 0)
        {
            go.platformcount++;
            PlayerPrefs.SetInt("platformcount", go.platformcount);
        }
        go.levelCount++;
        PlayerPrefs.SetInt("levelcount", go.levelCount);        
        gameEnded = true;
        movementui.SetActive(false);
        nextlvlui.SetActive(true);
        if (go.frequency % 10 == 0)
        {
            go.frequency--;
            PlayerPrefs.SetInt("frequency",go.frequency);
        }
    }
}
