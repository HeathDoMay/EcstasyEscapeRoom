using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        // accessing a grabble objects rigidbody
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        // updating the grab object via script
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
    }

    public void Drop()
    {
        // object is no longer in the grab location
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
    }

    private void FixedUpdate()
    {
        // if object is not null then there is an object near the grab point
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;

            // smooths out the objects movement when traveling to the grab point
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);

            // object that is grabbed will move towards the transform in from of the camera
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
