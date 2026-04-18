using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class EndGameScore : MonoBehaviour
{

    public float finalTime;

    public float Score;

    public float playerHealthLeft;

    public GameObject playerData;

    public TextMeshProUGUI finalTimeUI;
    public TextMeshProUGUI ScoreUI;


    public void Start()
    {

        finalTime = playerData.GetComponent<PlayerControl>().player_time;
        finalTimeUI.text = "Time: " + finalTime.ToString("0.00");

        playerHealthLeft = playerData.GetComponent<PlayerControl>().player_health;
        
        Score = playerHealthLeft * 500 + (1000 - finalTime);
        ScoreUI.text = "Score: " + Score.ToString();

    }

    public void Update()
    {
        finalTime = playerData.GetComponent<PlayerControl>().player_time;
        finalTimeUI.text = "Time: " + finalTime.ToString("0.00");


        playerHealthLeft = playerData.GetComponent<PlayerControl>().player_health;

        Score = playerHealthLeft * 500 + (1000 - finalTime);
        ScoreUI.text = "Score: " + Score.ToString();

    }
}
