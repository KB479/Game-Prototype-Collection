using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombSelf : MonoBehaviour
{

    public float lifeTime = 2f;


    void Update()
    {

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {

            Destroy(this.gameObject);

            //lifeTime = 2f;
        }


    } 




}   
