using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionTimer : MonoBehaviour
{

    private Action timerCallBack;    
    private float timer;

    public void SetTimer(float timer, Action timerCallBack)
    {
        this.timer = timer;
        this.timerCallBack = timerCallBack;
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (IsTimerComplete())
            {
                timerCallBack(); 

            }
        }

    }

    public bool IsTimerComplete()
    {
        return timer <= 0;
    }
        


}
