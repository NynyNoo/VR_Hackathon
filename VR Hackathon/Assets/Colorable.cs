using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Colorable : MonoBehaviour
{
    [SerializeField]
    private float BrightnessModifier;

    private Renderer Renderer;

    private void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
    }

    public void ChangeColor(float brushPower, Color brushColor)
    {
        Renderer.material.SetFloat("_Intensity", 100f);
        Renderer.material.SetColor("_BrushColor", brushColor);
    }
}
