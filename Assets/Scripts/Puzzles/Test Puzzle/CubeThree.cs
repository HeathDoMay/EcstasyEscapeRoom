using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeThree : MonoBehaviour
{
    public Transform attachPoint;
    public Transform cube;
    
    public bool cubeThreeCorret = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject (2)")
        {
            cube.transform.position = attachPoint.transform.position;

            cubeThreeCorret = true;

            Debug.Log("same location");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "TestPickUpObject (2)")
        {
            cubeThreeCorret = false;
        }
    }
}
