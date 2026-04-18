using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public bool player_alive = true;

    private GameObject player;
    private GameObject time_manager;

    public float player_time;
    public float player_health;


    public void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        time_manager = GameObject.FindGameObjectWithTag("TimeMan");

    }


    public void Update()
    {


        //player death
        if (player.GetComponent<PlayerManager>().playerHealth <= 0)
        {

            /*player.GetComponent<PlayerManager>().PlayerDeath(); 
            * Player destroy olduktan sonra da eriþmeye çalýþýyor, oyun çalýþýyor ama editör hata veriyor, þimdilik kullanmýyorum
            *  zaten death effect olmadýðý için ve ölünce oyun donduðu ve sýfýrlandýðý için objeyi yok etmeye gerek yok. */

            player_alive = false;
            player_time = 0;
            player_health = 0;

        }


        //player healt & time data
        if (player_alive)
        {
            player_health = player.GetComponent<PlayerManager>().playerHealth;
            player_time = time_manager.GetComponent<PlayerTime>().PassedTime;
        }



        /*
        Bu kod parçasý þimdilik gereksiz gibi, zaten DontDestroyOnLoad kullanýlmadýðý için restart atýnca sýfýrdan baþlýyor.
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            player_time = 0;
            player_health = 0;
            Destroy(this.gameObject);

        }else
        {
            //DontDestroyOnLoad(this.gameObject); 

        }

        //Bu kod parçasý þimdilik gereksiz gibi, zaten DontDestroyOnLoad kullanýlmadýðý için restart atýnca sýfýrdan baþlýyor.
        */


    }


}
