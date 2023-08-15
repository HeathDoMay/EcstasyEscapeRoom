using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberButtons : MonoBehaviour
{
    [Tooltip("Using a unity event in order to check if the password is correct.")]
    [SerializeField] private UnityEvent buttonPressed;

    public AudioSource audioSource;
    public AudioClip buttonSFX;

    // this method checks to see if a GameObject has a collider, on mouse click
    private void OnMouseDown()
    {
        // add sounds
        audioSource.PlayOneShot(buttonSFX);
        
        // Unity event is then invoked, call a method
        buttonPressed.Invoke();
    }
}
