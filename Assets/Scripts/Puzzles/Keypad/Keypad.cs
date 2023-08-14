using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    [Header("Keypad Password")]
    [SerializeField] private string password;
    private string userInput = "";

    [Header("Door Animator")]
    [SerializeField] private Animator animator;

    [Header("Text Ouput")]
    [SerializeField] private TextMeshPro text;

    [Space]
    [SerializeField] private GameObject numberColliders;

    [Space]
    public ChangeScreenMaterial screenMaterial;

    [Header("Audio")]
    public AudioClip[] keypadAudio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        userInput = "";
    }

    public void ButtonPressed(string number)
    {
        // everytime a button is pressed we add that data to the userInput variable
        userInput += number;
        text.text = userInput;

        // set color of the screen
        screenMaterial.Default();

        // check if usersInput is a length of 4
        if (userInput.Length >= 4)
        {
            if (userInput == password)
            {
                // add sound effects
                audioSource.PlayOneShot(keypadAudio[0]);

                // plays animation
                animator.SetTrigger("keypadDoorOpen");

                // reset text
                text.text = "";

                // deactive colliders so player can not press the buttons anymore
                numberColliders.SetActive(false);

                // set color of the screen
                screenMaterial.Green();
            }
            else
            {
                // add sound effects
                audioSource.PlayOneShot(keypadAudio[1]);

                // resets userInput to empty
                userInput = "";
                text.text = "";

                // set color of the screen
                screenMaterial.Red();
            }
        }
    }
}
