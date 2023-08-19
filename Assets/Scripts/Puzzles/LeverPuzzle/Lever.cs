using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [Tooltip("Using a unity event in order to check if the password is correct.")]
    [SerializeField] private UnityEvent leverPulled;
    [Space]
    public LeverPuzzle leverPuzzle;
    [Space]
    public Animator animator;
    [SerializeField] private AudioClip leverSFX;

    private AudioSource audioSource;
    private new Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // if the levers are pulled in the correct order, then the colliders that activate the puzzle will be disabled
        if (leverPuzzle.leverInput.Length >= 5)
        {
            if (leverPuzzle.leverInput == leverPuzzle.correctOrder)
            {
                collider.enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        // Play audio
        audioSource.PlayOneShot(leverSFX);

        animator.SetTrigger("pullLever");

        leverPulled.Invoke();
    }
}
