using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl1 : MonoBehaviour
{

    public GameObject player;


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            player.GetComponent<Transform>().transform.position = new Vector3(-10.35f, -4.305f, 0);

            player.GetComponent<PlayerManager>().playerHealth++;

            SceneManager.LoadScene(2);


        }


    }













}


    
    
 






