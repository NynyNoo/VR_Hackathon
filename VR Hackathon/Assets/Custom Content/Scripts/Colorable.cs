using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

using DG;
using DG.Tweening;

public class Colorable : MonoBehaviour
{
    [SerializeField]
    public float BrightnessModifier;
    [SerializeField]
    private float TweeningDuration = 0.5f;

    private Renderer Renderer;

    private void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
    }

    public void ChangeColor(float brushPower, Color brushColor)
    {

        DOTween.To(() => Renderer.material.GetFloat("_Intensity"),
            (x) => Renderer.material.SetFloat("_Intensity", x),
            1f, TweeningDuration);

        brushColor.r += BrightnessModifier;
        brushColor.g += BrightnessModifier;
        brushColor.b += BrightnessModifier;

        Renderer.material.SetColor("_BrushColor", brushColor);
    }
}