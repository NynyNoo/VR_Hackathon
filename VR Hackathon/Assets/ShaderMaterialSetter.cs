using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShaderMaterialSetter : MonoBehaviour
{
    [SerializeField]
    private Material ShaderMaterial;

    void Start()
    {
        SwapMaterialsInChildren();
        SwapSelvesMaterialIfNoChildren();
    }

    private void SwapSelvesMaterialIfNoChildren()
    {
        if (transform.childCount == 0)
        {
            Renderer renderer = this.GetComponent<Renderer>();
            SwapMaterial(renderer);
        }
    }
    private void SwapMaterialsInChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.tag != "Glass")
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                SwapMaterial(childRenderer);
            }
        }
    }

    private void SwapMaterial(Renderer renderer)
    {
        Material tempMaterial = new Material(ShaderMaterial);
        tempMaterial.SetColor("_StartingColor", renderer.material.color);
        renderer.material = tempMaterial;
    }
}
