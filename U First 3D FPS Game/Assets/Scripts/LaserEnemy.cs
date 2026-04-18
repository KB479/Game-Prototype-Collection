using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Obstacle, player_layer;


    void Start()
    {
        
    }


    void Update()
    {
        //LASER YAZILIM 1.07 GEREKLÝ ÝSE YAP, ÞEKÝL ÝLE ÝÞLEVÝ BÝRLEÞTÝR.

        //Laser Oluþturma
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, Obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f + Mathf.Sin(Time.time) / 75;

           
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        //Kill Player
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, player_layer))
        {

            hit.transform.gameObject.GetComponent<PlayerManager>().Death();
            /* Death fonksiyonunu çalýþtýrýyor, alttaki destroy kodunu da oraya ekle.
            Destroy(hit.transform.gameObject); */

        }




    }
}
