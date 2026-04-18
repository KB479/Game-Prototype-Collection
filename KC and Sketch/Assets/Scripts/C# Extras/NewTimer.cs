using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTimer : MonoBehaviour
{
    
    private float timer;

    public event EventHandler OnTimePassed; 


    public void SetTimer(float timer)
    {
        this.timer = timer;
    }

    private void Update()
    {
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            OnTimePassed?.Invoke(this, EventArgs.Empty);
        }

    }




}
