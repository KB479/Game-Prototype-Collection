using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    private GameObject player;
    private GameObject time_manager;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        time_manager = GameObject.FindGameObjectWithTag("TimeMan");

    }


    public void MainMenuButton()
    {

        SceneManager.LoadScene(0);

        Destroy(player);
        Destroy(time_manager);

    }

    public void Exit_btn()
    {

        Application.Quit();

    }



}
