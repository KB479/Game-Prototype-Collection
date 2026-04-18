using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameObject playerControl;

    public GameObject PausedCheck;



    public void Start()
    {

        DeathMenu.SetActive(false);

    }

    public void Update()
    {
        if (playerControl.GetComponent<PlayerControl>().player_alive == false && PausedCheck.GetComponent<PauseMenuUI>().isPaused == false)
        {

            DeathMenu.SetActive(true);
            Time.timeScale = 0f;


        }else if (playerControl.GetComponent<PlayerControl>().player_alive == true && PausedCheck.GetComponent<PauseMenuUI>().isPaused == false)
        {

            Time.timeScale = 1f;
        }
        else
        {

        }

        //timeScale'ler PauseMenu ile çakýþabiliyor dikkat et. Bu kod düzeltti durumu.

    }



    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void Exit_btn()
    {

        Application.Quit();

    }


}
