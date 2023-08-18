using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallMaterial : MonoBehaviour
{
    [SerializeField] private Material[] wallMaterials;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void Default()
    {
        renderer.material = wallMaterials[0];
    }

    public void Correct()
    {
        renderer.material = wallMaterials[1];
    }

    public void Error()
    {
        renderer.material = wallMaterials[2];
    }
}
