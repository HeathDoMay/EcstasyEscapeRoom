using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    public Transform attach;
    public Transform cube;
    public ObjectGrabbable objectGrabbable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "YellowCube" && objectGrabbable.grabbedObject == false)
        {
            cube.transform.position = attach.transform.position;
        }
    }
}
