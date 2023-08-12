using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberButtons : MonoBehaviour
{
    [Header("Button Number")]
    [SerializeField] private string number;

    [Tooltip("Using a unity event in order to check if the password is correct.")]
    public UnityEvent buttonPressed;

    // this method checks to see if a GameObject has a collider, on mouse click
    private void OnMouseDown()
    {
        // add sounds

        
        // Unity event is then invoked, call a method
        buttonPressed.Invoke();
    }
}
