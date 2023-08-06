using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOne : MonoBehaviour
{
    public bool yellowCube = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowCube"))
        {
            yellowCube = true;
            Debug.Log("Correct Cube");
        }

        if (other.gameObject.CompareTag("BlueCube"))
        {
            Debug.Log("Inncorect Cube");
        }

        if (other.gameObject.CompareTag("PinkCube"))
        {
            Debug.Log("Inncorect Cube");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("YellowCube"))
        {
            yellowCube = false;
            Debug.Log("Correct Cube");
        }
    }
}