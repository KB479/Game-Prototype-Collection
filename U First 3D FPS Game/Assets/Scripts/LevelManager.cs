using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    float timer = 10;

    public GameObject mesh;

    void Update()
    {

        timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(mesh, transform.position, Quaternion.identity);

            timer = 10;

        }
        

    }


}
