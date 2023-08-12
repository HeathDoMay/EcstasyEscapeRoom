using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    [Header("Keypad Password")]
    [SerializeField] private string password;
    private string userInput = "";

    [Header("Door Animator")]
    public Animator animator;

    private void Start()
    {
        userInput = "";
    }
    
    public void ButtonPressed(string number)
    {
        // everytime a button is pressed we had that data to the userInput variable
        userInput += number;

        if(userInput.Length >= 4)
        {
            if(userInput == password)
            {
                // add sound effects

                
                // plays animation
                animator.SetTrigger("keypadDoorOpen");
            }
            else
            {
                // add sound effects


                // resets userInput to empty
                userInput = "";
            }
        }
    }
}
