using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=2IhzPTS4av4&t=183s

    [Header("Player Inputs")]
    public PlayerInput playerInput;

    [Header("Variables")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private float pickUpDistance;
    [SerializeField] private LayerMask pickUpMask;

    [Header("UI Reference")]
    [SerializeField] private GameObject pressE;

    private ObjectGrabbable objectGrabbable;

    bool pickedUpObject;

    void Update()
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
                    }
                }
            }
            else
            {
                pressE.SetActive(false);
            }
        }

        // player holds R the object in hand will rotate
        if (pickedUpObject == true)
        {
            if (Input.GetKey(KeyCode.R))
            {
                objectGrabbable.Rotate();
            }
        }

        // press G to drop object, could make the player have to press E again to drop
        if (Input.GetKeyDown(playerInput.drop))
        {
            // currently carrying something, drop
            objectGrabbable.Drop();
            objectGrabbable = null;

            pickedUpObject = false;
        }
    }
}
