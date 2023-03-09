using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Renderer[] _characterRenderers;
    [SerializeField]
    private float _tweeningDuration = 5f;

    private float _passedTime;

    private void Start()
    {
        _characterRenderers = GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        if (_passedTime > 5f)
        {
            RestoreColorToCharacters(0.35f);
        }

        _passedTime += Time.deltaTime;
    }

    private void RestoreColorToCharacters(float intensity)
    {
        for (int i = 0; i < _characterRenderers.Length; i++)
        {
            DOTween.To(() => _characterRenderers[0].material.GetFloat("_Intensity"),
                (x) => _characterRenderers[0].material.SetFloat("_Intensity", x),
                intensity, 10f);
        }
    }
}
