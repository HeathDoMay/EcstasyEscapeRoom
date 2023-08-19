using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    [Tooltip("Order to pull levers. Each lever is assigned a number and if the lever order matches the correct order then something will happen")]
    public string correctOrder;
    public string leverInput;
    [Space]
    [SerializeField] private AudioClip[] leverAudio;
    [Space]
    public ChangeWallMaterial wallMaterial;

    private AudioSource audioSource;
    public Lever[] lever;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        correctOrder = "12345";
        leverInput = "";
    }

    public void LeverPulled(string leverNum)
    {
        leverInput += leverNum;
        wallMaterial.Default();

        if (leverInput.Length >= 5)
        {
            if (leverInput == correctOrder)
            {
                // play audio, change material, play animation
                audioSource.PlayOneShot(leverAudio[0]);
                wallMaterial.Correct();

                Debug.Log("You did it!");
            }
            else
            {
                // play audio, change material, play animation
                audioSource.PlayOneShot(leverAudio[1]);
                wallMaterial.Error();
                LeverResetAnim();
                leverInput = "";
                Debug.Log("incorrect try again");
            }
        }
    }

    private void LeverResetAnim()
    {
        lever[0].animator.SetTrigger("resetLever");
        lever[1].animator.SetTrigger("resetLever");
        lever[2].animator.SetTrigger("resetLever");
        lever[3].animator.SetTrigger("resetLever");
        lever[4].animator.SetTrigger("resetLever");
    }
}
