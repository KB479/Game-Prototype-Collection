using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 500f;

    public float lifeTime = 5f;

    public GameObject hit_effect;

    private void Update()
    { 

         
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime * speed);

        // Mermiler objesi yok olduktan sonra ateþ edince hata veriyor, deniz düzeltmedi daha

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            other.GetComponent<Drone>().health -= 25f;

        }

        Instantiate(hit_effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);


    }






}
