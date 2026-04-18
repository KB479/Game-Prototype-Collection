using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    public GameObject hand;

    public GameObject bullet;
    public Transform firePoint;

    private float coolDown;

    public AudioClip gunshot;
            
    void Update()
    {

        //Look

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset); //þimdilik iþlevsiz, silah açýsý ile ilgili
        }

        //Fire

        if (coolDown>0)
        {
            coolDown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            Instantiate(bullet, firePoint.position, transform.rotation * Quaternion.Euler(-90, 0, 0));

            GetComponent<Animator>().SetTrigger("shot");

            coolDown = 0.35f;


            /*Ses kaynaðý kameradan deðil direkt oyuncudan gelsin diye
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot) */

        }


 


    }


}
