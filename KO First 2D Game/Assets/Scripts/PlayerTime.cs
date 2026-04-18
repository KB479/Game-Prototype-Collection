using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerTime : MonoBehaviour
{

    public TextMeshProUGUI timeUI;

    private GameObject timee;

    public float PassedTime;


 
    public void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);

            PassedTime = 0f;

        }

        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

        }
        else
        {
            DontDestroyOnLoad(this.gameObject);

            PassedTime += Time.deltaTime;

            timee = GameObject.FindGameObjectWithTag("ttime");
            timeUI = timee.GetComponent<TextMeshProUGUI>();
            timeUI.text = PassedTime.ToString("0.00");

        }


    }



}
