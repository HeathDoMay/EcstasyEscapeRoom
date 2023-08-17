using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [Tooltip("Using a unity event in order to check if the password is correct.")]
    [SerializeField] private UnityEvent leverPulled;

    private void OnMouseDown()
    {
        // Play audio


        
        leverPulled.Invoke();
    }
}
