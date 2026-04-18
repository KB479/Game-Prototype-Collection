using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float speed = 100f;

    public float lifeTime = 5f;

    public float ball_radius;
    public LayerMask player_layer;

    

    private void Update()
    {

        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);

        }
        

        //Kill player

        if (Physics.CheckSphere(transform.position, ball_radius, player_layer))
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            

        }

    }









}