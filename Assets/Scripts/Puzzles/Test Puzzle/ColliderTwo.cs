using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTwo : MonoBehaviour
{
    public bool pinkCube = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PinkCube"))
        {
            pinkCube = true;
            Debug.Log("Correct Cube");
        }

        if (other.gameObject.CompareTag("BlueCube"))
        {
            Debug.Log("Inncorect Cube");
        }

        if (other.gameObject.CompareTag("YellowCube"))
        {
            Debug.Log("Inncorect Cube");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PinkCube"))
        {
            pinkCube = false;
            Debug.Log("Correct Cube");
        }
    }
}
