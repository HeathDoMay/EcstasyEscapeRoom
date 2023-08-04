using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=_QajrabyTJc

    [Header("Player Input and Controller")]
    public PlayerInput playerInput;
    [SerializeField] private CharacterController controller;

    [Header("Movement Values")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [Header("References")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    bool isCrouched;

    void Update()
    {
        Jumping();
        Crouching();
        Movement();
    }

    private void Movement()
    {
        // movement keys 
        float horizontal = Input.GetAxis("Horizontal"); // A, D
        float vertical = Input.GetAxis("Vertical"); // W, S

        // dircetion based on our X and Z locations
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // player moves
        if (move.magnitude >= 0.1f)
        {
            controller.Move(speed * Time.deltaTime * move);

            // if (Input.GetKey(KeyCode.LeftShift))
            // {
            //     float sprintMultipler = 1.5f;
            //     speed *= sprintMultipler;
            //     controller.Move(speed * Time.deltaTime * move);

            //     Debug.Log("sprinting");
            // }
        }
    }

    private void Jumping()
    {
        /*
            creates a sphere at the bottom of the player 
            which uses the distance from the groud to the player (0.4f)
            and checks for the layer mask GroundMask.

            groundCheck = postion, groundDistance = radius, groundMask is the Layermask we are looking for
        */

        bool isGrounded;

        // collides with groundMask isGrounded = true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // will force player to ground if isGrounded = false and vecloctiy.y is less than 0 (-9.81)
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // creating gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Crouching()
    {
        float crouchHeight = 1.8f;
        float normalHeight = 3.6f;

        // crouching, CTRL
        if (Input.GetKey(playerInput.crouchOne))
        {
            isCrouched = true;
        }
        else
        {
            isCrouched = false;
        }

        if (isCrouched == true)
        {
            controller.height = crouchHeight;
            speed = 6;
        }
        else
        {
            controller.height = normalHeight;
            speed = 12;
        }
    }
}