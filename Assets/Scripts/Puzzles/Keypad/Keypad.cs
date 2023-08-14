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

    public ChangeScreenMaterial screenMaterial;

    private void Start()
    {
        userInput = "";
    }

    public void ButtonPressed(string number)
    {
        // everytime a button is pressed we add that data to the userInput variable
        userInput += number;
        text.text = userInput;

        screenMaterial.Default();
        text.color = Color.black;

        // check if usersInput is a length of 4
        if (userInput.Length >= 4)
        {
            if (userInput == password)
            {
                // add sound effects

                // plays animation
                animator.SetTrigger("keypadDoorOpen");

                text.text = "";
                screenMaterial.Green();
                // text.color = Color.green;
                numberColliders.SetActive(false);
            }
            else
            {
                // add sound effects

                // resets userInput to empty
                userInput = "";
                text.text = "";
                screenMaterial.Red();
            }
        }
    }
}
