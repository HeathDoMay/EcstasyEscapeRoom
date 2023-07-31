using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=_QajrabyTJc

    [Header("Mouse Sensitivity")]
    public float mouseSensitivity;

    [Header("Player")]
    public Transform playerBody;

    // default x rotaion value
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lock the cursor to the center of the screen and make it not visible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // getting the x and y axis for the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // decrease X rotation based on mouse Y
        xRotation -= mouseY;

        // makes sure we dont over look behind the player
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // keeps track of xRotation in order to clamp the value
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}