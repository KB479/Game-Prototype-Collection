using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float spawnTimer = 3f;
    public GameObject enemy;



    public void Awake()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    public void Update()
    {

        spawnTimer -= Time.deltaTime;
        

        if (spawnTimer <= 0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);


            spawnTimer = 3f;

        }


    }

}
