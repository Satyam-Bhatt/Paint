using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Handler : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject died;
    [SerializeField] private GameObject start_Panel;
    [SerializeField] private GameObject hint_Panel;

    public bool paused = false;

    [HideInInspector]
    public bool playerDied = false;

    [HideInInspector]
    public bool startPanelOn = true;

    private bool open_Hint = false;
    private int clickNumber = 0;

    [SerializeField]  private HintSystem hintSystem;

    private void Awake()
    {
        pause.SetActive(false);
        died.SetActive(false);
        hint_Panel.SetActive(false);
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

    public void BeginGame()
    {
        start_Panel.SetActive(false);
        startPanelOn = false;
    }

    public void HintPanelActivate()
    {
        if (open_Hint == false)
        {
            hint_Panel.SetActive(true);
            open_Hint = true;
            clickNumber++;
            if(clickNumber > 1)
            {
                hintSystem.NextHint();
            }
        }
        else
        {
            hint_Panel.SetActive(false);
            open_Hint = false;
        }
        
    }
}
