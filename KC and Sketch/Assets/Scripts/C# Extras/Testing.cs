using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private ActionTimer actionTimer;



    private void Start()
    {
        actionTimer.SetTimer(1f, () => { Debug.Log("Timer Complete!"); });  

    }

    

}
