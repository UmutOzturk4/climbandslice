using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    bool IsPaused = false;
    public bool EndlessLocked = true;
    public GameObject pauseUI;
    public GameObject endlesstxt;
    public void Start()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ResetLevels()
    {
        PlayerPrefs.SetInt("levelcount", 1);
        PlayerPrefs.SetInt("platformcount", 1);
        PlayerPrefs.SetInt("frequency", 4);
    }
    public void IsPause()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    public void endless()
    {
        if (EndlessLocked) 
        {
            endlesstxt.SetActive(true);
            Invoke("endlesstxtinvisible",4f);
        }
    }
    public void endlesstxtinvisible()
    {
        endlesstxt.SetActive(false);
    }

}
