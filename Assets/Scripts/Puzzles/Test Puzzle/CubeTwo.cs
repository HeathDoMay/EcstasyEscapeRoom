using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTwo : MonoBehaviour
{
    public Transform attachPoint;
    public Transform cube;
    
    public bool cubeTwoCorret = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject (1)")
        {
            cube.transform.position = attachPoint.transform.position;

            cubeTwoCorret = true;

            Debug.Log("same location");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject (1)")
        {
            cubeTwoCorret = false;
        }
    }
}
