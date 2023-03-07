using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFromDisolveHandler : MonoBehaviour
{
    [SerializeField] float visibility;
    [SerializeField] float duration=5f;
    private Renderer renderer;
    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    public void ShowObject()
    {
       
        DOTween.To(() => renderer.material.GetFloat("_Visibility"),
            (x) => renderer.material.SetFloat("_Visibility", x),
            2f, duration);
    }
    public void SetColor(Color _color)
    {
        renderer.material.SetColor("_StartingColor", _color);
    }
}
