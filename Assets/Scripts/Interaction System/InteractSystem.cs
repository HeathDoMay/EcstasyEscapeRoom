using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    // Reference: https://www.youtube.com/watch?v=2IhzPTS4av4&t=183s

    [Header("Player Inputs")]
    public PlayerInput playerInput;

    public GameObject canvas;

    [Header("Variables")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private float pickUpDistance;
    [SerializeField] private LayerMask pickUpMask;

    private ObjectGrabbable objectGrabbable;

    void Update()
    {
        if (Input.GetKeyDown(playerInput.interact))
        {
            if (objectGrabbable == null)
            {
                // not carrying an object, try to grab
                // raycast will hit everything in from of the camera 
                if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, pickUpDistance, pickUpMask))
                {
                    Debug.Log(raycastHit.transform);

                    // will test to see if the object the player presses E on has the script ObjectGrabbable
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            // press E to drop object
            // else
            // {
            //     // currently carrying something, drop
            //     objectGrabbable.Drop();
            //     objectGrabbable = null;
            // }
        }

        // press G to drop object
        if (Input.GetKeyDown(playerInput.drop))
        {
            // currently carrying something, drop
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
    }
}
