using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nihao : MonoBehaviour
{

    [SerializeField] private NewTimer timer;

    private void Awake()
    {
        timer.OnTimePassed += Timer_OnTimePassed;
    }

    private void Start()
    {
        timer.SetTimer(5f); 
    }

    private void Timer_OnTimePassed(object sender, System.EventArgs e)
    {
        Debug.Log("Nihao!");

    }
}
