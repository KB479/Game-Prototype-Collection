using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isGameRunning = true;
    public bool isGameOver = false;

    public GameObject psm;
    public GameObject player, pistol;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {

            if (isGameRunning)
            {
                Pause();

                isGameRunning = false;

            }
            else
            {
                Resume();

                isGameRunning = true;
            }

        }

    }
    public void Pause() 
    {
        //Frozen
        Time.timeScale = 0;

        //Disable movement and pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;


        //Pause UI
        psm.SetActive(true);

        //Cursor Activate
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Resume() 
    {
        //Unfrozen
        Time.timeScale = 1;

        //Disable movement and pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;

        //Pause UI deactivate
        psm.SetActive(false);

        //Cursor Deactivate
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitButton() 
    {

        Application.Quit();

    }


}
