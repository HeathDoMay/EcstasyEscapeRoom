using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObjects : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(animator != null)
        {
            animator.SetTrigger("openTrigger");
        }
    }

    public void CloseDoor()
    {
        if(animator != null)
        {
            animator.SetTrigger("closeTrigger");
        }
    }
}
