using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenMaterial : MonoBehaviour
{
    public Material[] materials;
    private new Renderer renderer;
    
    // public float duration = 5f;
    // public Keypad keypad;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    }

    public void Default()
    {
        renderer.sharedMaterial = materials[0];
    }

    public void Green()
    {
        renderer.sharedMaterial = materials[1];
    }

    public void Red()
    {
        renderer.sharedMaterial = materials[2];
    }

    // NEEDS TO BE PLACED IN THE UPDATE FUNCTION TO WORK PROPERLY
    // public void SwapColors()
    // {
    //     if (keypad.userInput == keypad.password)
    //     {
    //         // ping-pong between the materials over the duration and length of PingPong
    //         renderer.material.Lerp(materials[0], materials[1], Mathf.PingPong(Time.time * duration, 2));
    //     }
    // }
}
