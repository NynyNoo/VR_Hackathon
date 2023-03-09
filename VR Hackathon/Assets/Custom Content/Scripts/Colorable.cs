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
    private float TweeningDuration = 15f;
    private GameProgressCounter gameProgressCounter;
    private bool risedCounter=false;
    public ScriptableObject scriptable;

    private Renderer Renderer;
    private GameProgressCounter _progressCounter;

    private void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
        GameObject gameplayObject = GameObject.Find("Gameplay");
        gameProgressCounter = gameplayObject.GetComponent<GameProgressCounter>();

    }

    public void ChangeColor(float brushPower, Color brushColor, bool isColoredByItsOwnCollider)
    {
        if(isColoredByItsOwnCollider == true && risedCounter == false)
        {
            gameProgressCounter.UpdateCounter(gameObject.name);
            risedCounter = true;
        }

        DOTween.To(() => Renderer.material.GetFloat("_Intensity"),
            (x) => Renderer.material.SetFloat("_Intensity", x),
            1f, TweeningDuration);

        brushColor.r += BrightnessModifier;
        brushColor.g += BrightnessModifier;
        brushColor.b += BrightnessModifier;

        Renderer.material.SetColor("_BrushColor", brushColor);
    }
}
