using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Handler : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject died;

    public bool paused = false;

    [HideInInspector]
    public bool playerDied = false;

    private void Awake()
    {
        pause.SetActive(false);
        died.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pause.SetActive(true);
                paused = true;
                Time.timeScale = 0f;
            }
            else 
            { 
                pause.SetActive(false);
                paused = false;
                Time.timeScale = 1f;
            }
            
        }

        if (playerDied)
        {
            died.SetActive(true);
        }
    }

    public void ResumeFormPauseScreen()
    {
        paused = false;
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
