using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{

    public GameObject bomb;

    public float bombTimer = 3f;
    public int bombNum = 20;

    public Vector2 areaSize = new Vector2(16, 6);


    public void Awake()
    {
        BombDown();
    }

    public void Update()
    {
        
        bombTimer -= Time.deltaTime;

        if ( bombTimer <= 0)
        {
            BombDown();
            bombTimer = 3f;

        }

    }

    public void BombDown()
    {

        for(int i = 0; i < bombNum; i++)
        {

            Vector2 randomPosition = new Vector2(Random.Range(-areaSize.x / 2, areaSize.x / 2),  
                                                 Random.Range(-areaSize.y / 2, areaSize.y / 2));

            Instantiate(bomb, randomPosition, Quaternion.identity);

        }


    }






}
