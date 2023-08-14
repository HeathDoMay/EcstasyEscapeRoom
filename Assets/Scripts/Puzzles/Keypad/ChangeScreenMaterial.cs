using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenMaterial : MonoBehaviour
{
    public Material[] materials;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = materials[0];
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
}
