using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerManager : MonoBehaviour
{

    public TextMeshProUGUI healthUI;
    private GameObject healthh;

    private GameObject playerControl;
    public float speed = 3f;
    public float playerHealth = 3f;
    private static PlayerManager instance;
    public GameObject deathUI;

    public Rigidbody2D rb;

    public void Awake()
    {

        playerControl = GameObject.FindGameObjectWithTag("PlayerControl");

    }



    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);

        }else if (SceneManager.GetActiveScene().buildIndex == 4)
        {

            this.gameObject.SetActive(false); //endgame'de playerdan data alaca��m�z i�in destroy kullanma.

        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerMovement();

            healthh = GameObject.FindGameObjectWithTag("hhealth");
            healthUI = healthh.GetComponent<TextMeshProUGUI>();
            healthUI.text = playerHealth.ToString();

        }

    }

    //player movement
    public void PlayerMovement()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); // * speed * Time.deltaTime;
        //transform.position = transform.position + move * speed * Time.deltaTime; 


        rb.velocity = new Vector2(move.x, move.y)*speed; 
        //fizik temelli hareket i�in, duvardan sekmiyor b�ylece. froze z unutma.

    }


    //player gets damage
    public void OnTriggerEnter2D(Collider2D other)
    {
        //trap hit
        if (other.CompareTag("Trap1"))
        {
            playerHealth -= 1;

            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }else if (other.CompareTag("Trap2"))
        {
            playerHealth -= 1.5f;

            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
        else if (other.CompareTag("Trap3"))
        {
            playerHealth -= 3;

            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }

        //bomb hit
        if (other.CompareTag("Bomb"))
        {

            playerHealth -= 1;

        }

        //enemy hit
        if (other.gameObject.CompareTag("Enemy"))
        {

            playerHealth -= 1;

        }

    }
 

    //player death
    public void PlayerDeath()
    {

        //death effect


        Destroy(this.gameObject);

        

    }







}
