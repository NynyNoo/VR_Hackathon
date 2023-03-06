using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderMaterialSetter : MonoBehaviour
{
    [SerializeField]
    private Material ShaderMaterial;

    private Material[] ChildrenMaterials;

    void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.tag != "Glass")
            {
                ChildrenMaterials = GetComponentsInChildren<Material>();

                for (int i = 0; i < ChildrenMaterials.Length; i++)
                {
                    ShaderMaterial.color = ChildrenMaterials[i].color;
                    ChildrenMaterials[i] = ShaderMaterial;
                }
            }
        }
    }
}
