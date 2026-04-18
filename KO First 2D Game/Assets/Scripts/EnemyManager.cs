using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public LayerMask playerLayer;

    private Transform player;

    public float enemeySpeed = 10f;
    

    public GameObject playerControl;


    public void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    public void Update() 
    {
        transform.Translate(Vector2.left * enemeySpeed * Time.deltaTime);

    }


 



}




