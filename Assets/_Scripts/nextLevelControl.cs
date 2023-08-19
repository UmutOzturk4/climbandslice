using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelControl : MonoBehaviour
{
    GameObject[] enemiesInScene;

    public TMPro.TMP_Text leveltxt;
    public TMPro.TMP_Text scoretxt;

    public bool gameEnded=false;
    bool invoked = false;
    public GameObject movementui;
    public GameObject nextlvlui;
    InstantiateFloor IF;
    private void Start()
    {
        IF = this.gameObject.GetComponent<InstantiateFloor>();    
    }
    void Update()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("enemy");
        if (enemiesInScene.Length == 0 && !invoked)
        {
            //invoked = true;
            //Invoke("Nextlevel", 1);
        }
        leveltxt.text = "level " + PlayerPrefs.GetInt("levelcount");
        scoretxt.text = "score " + IF.GetComponentInParent<Movement>().score;
    }
    public void Nextlevel()
    {    
        if (IF.levelCount % 2 == 0)
        {
            IF.platformcount++;
            PlayerPrefs.SetInt("platformcount", IF.platformcount);
        }
        IF.levelCount++;
        PlayerPrefs.SetInt("levelcount", IF.levelCount);        
        gameEnded = true;
        movementui.SetActive(false);
        nextlvlui.SetActive(true);
        if (IF.frequency % 10 == 0)
        {
            IF.frequency--;
            PlayerPrefs.SetInt("frequency",IF.frequency);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
