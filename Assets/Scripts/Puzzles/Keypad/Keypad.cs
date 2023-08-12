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

    [Header("Screen Ouput")]
    [SerializeField] private TextMeshPro screen;

    [Space]
    [SerializeField] private GameObject numberColliders;
    private void Start()
    {
        userInput = "";
    }
    
    public void ButtonPressed(string number)
    {
        // everytime a button is pressed we add that data to the userInput variable
        userInput += number;
        screen.text = userInput;

        screen.color = Color.black;

        // check if usersInput is a length of 4
        if(userInput.Length >= 4)
        {
            if(userInput == password)
            {
                // add sound effects

                // plays animation
                animator.SetTrigger("keypadDoorOpen");
                screen.text = "CORRECT!";
                numberColliders.SetActive(false);
            }
            else
            {
                // add sound effects

                // resets userInput to empty
                userInput = "";
                screen.text = "ERROR!";
            }
        }
    }
}
