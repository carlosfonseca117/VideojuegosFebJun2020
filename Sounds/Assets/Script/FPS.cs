using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    //GameObject del FPS
    public GameObject fps;

    //Variables para el movimiento de la vista 
    public float mouseSensitive = 10f;
    private float mouseX;
    private float mouseY;
    private float rotationX;

    //Variables para el movimiento

    public float speed = 10f;
    public float jumpHeight = 2f;
    
    private float moves2s;
    private float movefb;
    private float moveud;
    private float gravity = -9.81f;
    private bool isGrounded;

    private Vector3 movimiento;
    private CharacterController controller;
  

    //Variables para un ground más estable

    public GameObject magicSphere;
    public LayerMask groundMask;
    private float radious = 0.2f;
    



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = fps.GetComponent<CharacterController>();
    }

    void Update()
    {

        FPSlook();
        FPSMove();
    }

    public void FPSMove()
    {


        //isGrounded = controller.isGrounded; //Version grounded usando el Character Controller

        isGrounded = Physics.CheckSphere(magicSphere.transform.position, radious, groundMask);
        
        
        if (isGrounded)
            moveud = 0;
        else
            moveud += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
            moveud = Mathf.Sqrt(jumpHeight * -2f * gravity);

        movefb = Input.GetAxis("Vertical");
        moves2s = Input.GetAxis("Horizontal");
        
        movimiento = ((fps.transform.right * moves2s)+
                      (fps.transform.up*moveud)+
                      (fps.transform.forward*movefb));
        movimiento = movimiento * speed * Time.deltaTime;
        controller.Move(movimiento);


    }

    public void FPSlook()
    {
        mouseX = Input.GetAxis("Mouse X")*mouseSensitive*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")*mouseSensitive*Time.deltaTime;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        fps.transform.Rotate(Vector3.up, mouseX);
    }
}
