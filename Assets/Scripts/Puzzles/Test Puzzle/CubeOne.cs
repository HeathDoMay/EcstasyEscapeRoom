using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOne : MonoBehaviour
{
    public Transform attachPoint;
    public Transform cube;
    
    public bool cubeOneCorret = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject")        
        {
            cube.transform.position = attachPoint.transform.position;

            cubeOneCorret = true;

            Debug.Log("same location");
        }
        else
        {
            cubeOneCorret = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject")
        {
            cubeOneCorret = false;
        }
    }
}
