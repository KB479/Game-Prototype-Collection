using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl3 : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Transform>().transform.position = new Vector3(-10.35f, -4.305f, 0);

            

            SceneManager.LoadScene(4);

        }


    }













}


    
    
 






