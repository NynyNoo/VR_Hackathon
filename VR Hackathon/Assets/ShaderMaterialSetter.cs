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
        SwapMaterialsForAllColorableChildren();
    }

    private void SwapMaterialsForAllColorableChildren()
    {
        Colorable[] childrensColorables = this.GetComponentsInChildren<Colorable>();

        foreach(var colorable in childrensColorables)
        {
            Renderer renderer = colorable.gameObject.GetComponent<Renderer>();
            SwapMaterial(renderer);
        }
    }

    private void SwapMaterial(Renderer renderer)
    {
        Material tempMaterial = new Material(ShaderMaterial);
        tempMaterial.SetColor("_StartingColor", renderer.material.color);
        renderer.material = tempMaterial;
    }
}
