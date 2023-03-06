using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

using DG;
using DG.Tweening;

public class Colorable : MonoBehaviour
{
    [SerializeField]
    private float BrightnessModifier;
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

        Renderer.material.SetColor("_BrushColor", brushColor);
    }
}
