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
    private float TweeningDuration = 15f;
    private GameProgressCounter gameProgressCounter;
    private bool risedCounter=false;
    public ScriptableObject scriptable;

    private Renderer Renderer;

    private void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
        GameObject gameplayObject = GameObject.Find("Gameplay");
        gameProgressCounter = gameplayObject.GetComponent<GameProgressCounter>();

    }

    public void ChangeColor(float brushPower, Color brushColor)
    {
        DOTween.To(() => Renderer.material.GetFloat("_Intensity"),
            (x) => Renderer.material.SetFloat("_Intensity", x),
            1f, TweeningDuration);
        Renderer.material.SetColor("_BrushColor", brushColor);
        if (!risedCounter)
            RiseCounter();
    }
    private void RiseCounter()
    {
        if (gameProgressCounter != null)
        {
            gameProgressCounter.UpdateCounter(gameObject.name);
            risedCounter = true;
        }
    }
}
