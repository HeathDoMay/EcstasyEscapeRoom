using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=2IhzPTS4av4&t=183s

    [Header("Player Inputs and Camera")]
    public PlayerInput playerInput;
    [SerializeField] private Transform playerCamera;

    [Header("Grab and Drop")]
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private float pickUpDistance;
    [SerializeField] private LayerMask pickUpMask;

    [Header("Open Objects")]
    [SerializeField] private LayerMask openMask;
    [SerializeField] private float openDistance;
    bool isOpen = false;

    [Header("UI Reference")]
    [SerializeField] private GameObject pressE;

    private ObjectGrabbable objectGrabbable;
    private OpenObjects openObjects;
    private bool pickedUpObject;

    void Update()
    {
        GrabAndDropObjects();

        // raycast that will detect an object with the "Door/Chest"
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, openDistance, openMask))
        {
            Debug.Log(raycastHit.transform);
            pressE.SetActive(true);

            if (isOpen == false)
            {
                if (Input.GetKeyDown(playerInput.interact))
                {
                    // checks if the door has the script OpenObjects
                    if (raycastHit.transform.TryGetComponent(out openObjects))
                    {
                        // plays animation
                        openObjects.OpenDoor();
                        isOpen = true;
                        Debug.Log(isOpen);
                    }
                }
            }
            else if (isOpen == true)
            {
                if (Input.GetKeyDown(playerInput.interact))
                {
                    if (raycastHit.transform.TryGetComponent(out openObjects))
                    {
                        // plays animation
                        openObjects.CloseDoor();
                        isOpen = false;
                        Debug.Log(isOpen);
                    }
                }
            }
            else
            {
                isOpen = false;
            }
        }
    }

    private void GrabAndDropObjects()
    {
        if (objectGrabbable == null)
        {
            // not carrying an object, try to grab
            // raycast will only detect objects with the layer mask "Objects"
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, pickUpDistance, pickUpMask))
            {
                Debug.Log(raycastHit.transform);
                pressE.SetActive(true);

                if (Input.GetKeyDown(playerInput.interact))
                {
                    // will test to see if the object the player presses E on has the script ObjectGrabbable
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        pressE.SetActive(false);
                        objectGrabbable.Grab(objectGrabPointTransform);

                        pickedUpObject = true;
                        Debug.Log(pickedUpObject);
                    }
                }
            }
            else
            {
                pressE.SetActive(false);
            }
        }

        // player holds R the object in hand will rotate
        // if (pickedUpObject == true)
        // {
        //     if (Input.GetKey(playerInput.rotate))
        //     {
        //         objectGrabbable.Rotate();
        //     }
        // }

        // press G to drop object, could make the player have to press E again to drop
        if (Input.GetKeyDown(playerInput.drop))
        {
            // currently carrying something, drop
            objectGrabbable.Drop();
            objectGrabbable = null;

            pickedUpObject = false;
            Debug.Log(pickedUpObject);
        }
    }
}
