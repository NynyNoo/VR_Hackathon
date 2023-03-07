using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColor : MonoBehaviour
{
    private Renderer renderer;
    private float duration=2.5f;
    [SerializeField]public Color color;
    public void ColorGrass()
    {
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);
        DOTween.To(() => renderer.material.GetFloat("_ColoringState"),
            (x) => renderer.material.SetFloat("_ColoringState", x),
            1.5f, duration);
    }
}
