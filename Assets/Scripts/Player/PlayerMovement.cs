using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=_QajrabyTJc

    [Header("Player Controller")]
    [SerializeField] private CharacterController controller;

    [Header("Movement Values")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [Header("References")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public PlayerInput playerInput;

    Vector3 velocity;
    bool isGrounded;
    bool isCrouched;



    void Update()
    {
        Jumping();
        Crouching();

        // movement keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // dircetion based on our X and Z locations
        Vector3 move = transform.right * x + transform.forward * z;

        // player moves
        controller.Move(move * speed * Time.deltaTime);

        // crouching, C or CTRL
        if (Input.GetKeyDown(playerInput.crouchOne))
        {
            isCrouched = true;
        }

        if (Input.GetKeyUp(playerInput.crouchOne) && isCrouched == true)
        {
            isCrouched = false;
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

        if (isCrouched == true)
        {
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = normalHeight;
        }
    }
}