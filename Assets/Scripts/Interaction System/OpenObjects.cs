using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObjects : MonoBehaviour
{
    public Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if(doorAnim != null)
        {
            doorAnim.SetTrigger("openTrigger");
        }
    }

    public void CloseDoor()
    {
        if(doorAnim != null)
        {
            doorAnim.SetTrigger("closeTrigger");
        }
    }
}
