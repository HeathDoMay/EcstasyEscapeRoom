using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=_QajrabyTJc

    [Header("Player Controller")]
    public CharacterController controller;

    [Header("Movement Values")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [Header("References")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        /*
            creates a sphere at the bottom of the player 
            which uses the distance from the groud to the player (0.4f)
            and checks for the layer mask GroundMask.

            groundCheck = postion, groundDistance = radius, groundMask is the Layermask we are looking for
        */ 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // collides with groundMask isGrounded = true

        // will force player to ground if isGrounded = false and vecloctiy.y is less than 0 (-9.81)
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // movement keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // dircetion based on our X and Z locations
        Vector3 move = transform.right * x + transform.forward * z;

        // player moves
        controller.Move(move * speed * Time.deltaTime);

        // jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // creating gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}