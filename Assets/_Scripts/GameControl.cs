using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    InstantiateFloor go;
    Scene scene;
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");       
    }  
    public void Quit()
    {
        Application.Quit();
    }
    public void ResetLevels()
    {
        PlayerPrefs.SetInt("levelcount",1);
        PlayerPrefs.SetInt("platformcount", 1);
        PlayerPrefs.SetInt("frequency", 4);
    }
}
