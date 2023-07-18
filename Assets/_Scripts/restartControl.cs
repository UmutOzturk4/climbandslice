using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartControl : MonoBehaviour
{
    GameObject[] enemiesInScene;
    void Update()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("enemy");
        if (enemiesInScene.Length == 0)
        {
            Invoke("Restart", 4);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
