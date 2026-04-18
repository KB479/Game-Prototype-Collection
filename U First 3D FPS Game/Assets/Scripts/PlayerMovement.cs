using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    private CharacterController controller;
    public float speed = 30f;
        
    //Camera Controller
    public float mouseSensevity = 5f;
    private float xRotation = 0f;

    //Jump & Gravity
    private Vector3 velocity;
    private float Gravity = -9.81f;
    private bool isGround;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;
        

    public float jumpHeight = 0.01f;
    public float gravityDivide = 50f;
    public float jumpSpeed = 30f;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //Cursor deactivate
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Check character is grounded
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        //Movement
        Vector3 playerInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = playerInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);
        /* Move fonksiyonu translate ile benzer iþi görüyor. Sadece bu fonksiyonu için playerInput yukarýdaki gibi vektör
        toplamasý þeklinde yapýlmalý, derste ilk öðrendiðim þekilde yapýnca harekette kamera uyuþmazlýðý yaþanýyor*/


        //Camera Controller
        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensevity;
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensevity;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);      
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * MouseX);

        /*
        Bu yazým, ilk öðrendiðim hali ve temiz çalýþýyor. Deniz bundan farklý biçimde yazdý, aynýsýný yazdým düzgün çalýþmadý.
        Eski kodun yenisinden farký þuydu: Input*time.deltatime, yerel deðiþkende (açýk mavi) gösterildi. Sonra xRotation
        buna eþitlendi ve kod yazýldý. Yenisinde direkt Input*time.deltatime = xRotation dendi. Böyle olunca kamera olmasý 
        gerekenden çok daha yavaþ döndü. Time.deltatime silinince düzeldi ama. Sorun neydi? Tahminim, Input*time.deltaTime
        yapýsý yerel deðiþkende gösterilmeden koda yazýlmamalý. Araþtýr burayý.
        
        Denizin Yazdýðý Kod:

        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime, 0f);
        */


        //Jump & Gravity
        if (!isGround)
        {
            velocity.y += Gravity * Time.deltaTime / gravityDivide;
            speed = jumpSpeed; 
            /* Zýplama esnasýnda havadaki hýzý kontrol etmek için*/
        }
        else
        {
            velocity.y = -0.05f;      
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *  Gravity); //sayýlarýn karesini alan math formülü. float deðer de yazýlabilirdi.
        }

        controller.Move(velocity);
        





    }




}
