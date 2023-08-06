using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderThree : MonoBehaviour
{
    public bool blueCube = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueCube"))
        {
            blueCube = true;
            Debug.Log("Correct Cube");
        }

        if (other.gameObject.CompareTag("PinkCube"))
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
        if (other.gameObject.CompareTag("BlueCube"))
        {
            blueCube = false;
            Debug.Log("Correct Cube");
        }
    }
}
