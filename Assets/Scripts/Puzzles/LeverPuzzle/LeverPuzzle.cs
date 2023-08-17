using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    [SerializeField] private string correctOrder;
    private string leverInput; 
    [SerializeField] private GameObject levers;

    public void LeverPulled(string leverNum)
    {
        leverInput += leverNum;

        if(leverInput.Length >= 5)
        {
            if(leverInput == correctOrder)
            {
                // play audio, change material, play animation



                Debug.Log("You did it!");
            }
            else
            {
                // play audio, change material, play animation



                leverInput = "";
                Debug.Log("incorrect try again");
            }
        }
    }
}
