using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -2f;
    public float jumpHeight = 2f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //laver usynlig cirkel som tjekker om spilleren rør jorden
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //hvis spilleren rør jorden reseter downward velocity
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        //input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //hoppe
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //tyngdekraft
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
