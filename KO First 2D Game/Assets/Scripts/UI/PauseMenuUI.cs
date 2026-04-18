using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

    public GameObject PauseMenu;

    public GameObject PlayerControl;

    public bool isPaused;

    public void Start()
    {
        
        //PauseMenu.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerControl.GetComponent<PlayerControl>().player_alive == true)
        {
           
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }


        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;

        isPaused = false;
    }

    public void MainMenuButton()
    {
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }


    public void Exit_btn()
    {

        Application.Quit();

    }
}
