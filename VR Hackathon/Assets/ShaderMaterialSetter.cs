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
        foreach (Transform child in transform)
        {
            if (child.tag != "Glass")
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                Material tempMaterial = new Material(ShaderMaterial);
                tempMaterial.SetColor("_StartingColor", childRenderer.material.color);
                childRenderer.material = tempMaterial;
            }
        }
    }
}
