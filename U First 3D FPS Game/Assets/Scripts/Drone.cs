using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;
    public float droneSpeed = 1f;
    public float follow_distance = 10f;
    public float drone_rotate_speed = 20f;

    public GameObject energy_ball;
    public GameObject death_effect;

    private float cool_down;

    public float health = 100f;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {
      
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(-90, 0, 0));

        if(Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * droneSpeed * Time.deltaTime * -1);
        }
        else
        {
            transform.RotateAround(player.position, new Vector3(0, 1, 0), drone_rotate_speed * Time.deltaTime);
 
        }

    }

    private void Shot()
    {

        if (cool_down > 0)
        {
            cool_down -= Time.deltaTime;
        }
        else
        {
            cool_down = 2f;
            Instantiate(energy_ball, transform.position, transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)));

        }


    }

    private void Death()
    {

        if(health<=0)
        {

            Destroy(this.gameObject);
            Instantiate(death_effect, transform.position, Quaternion.identity);

        }
       

    }



}
