using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelf : MonoBehaviour
{

    public float lifeTime = 3f;

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
