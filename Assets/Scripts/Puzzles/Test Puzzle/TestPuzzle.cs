using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzle : MonoBehaviour
{
    public ColliderOne colliderOne;
    public ColliderTwo colliderTwo;
    public ColliderThree colliderThree;

    private void Update()
    {
        if(colliderOne.yellowCube == true && colliderTwo.pinkCube == true && colliderThree.blueCube == true)
        {
            Debug.Log("Puzzle Solved");
        }
        else
        {
           // Debug.Log("Try Again");
        }
    }
}
