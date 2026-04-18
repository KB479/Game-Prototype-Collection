using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{

    public float spawnTimer = 3f;
    public GameObject enemy;


    public void Update()
    {

        spawnTimer -= Time.deltaTime;

        EnemyMove();

        if (spawnTimer <= 0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            spawnTimer = 3f;

        }


    }

    public void EnemyMove()
    {


        //enemy.transform.Translate(Vector2.left * speed * Time.deltaTime);

        //print(speed);


    }



}
