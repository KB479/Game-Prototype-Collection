using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject death_effect;
    private bool player_alive = true;

    public GameObject hand;
    public GameObject crosshair;
    public GameObject gameOverMenu;
    public PauseMenu pauseMenu;
    public GameObject enemySpawner;


    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            //Pause Menu control
            pauseMenu.isGameOver = true;

            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //Disable player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //Cursor Activate
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //UI Active
            gameOverMenu.SetActive(true);

            //Stop Drone Spawn
            Destroy(enemySpawner);




        } 

        //If yapýsý player bir kere öldükten sonra effectin tekrarlanmamasýný saðlýyor.

    }







}
