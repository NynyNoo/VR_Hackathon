using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorRestoreBehaviour : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    public void RestoreColor(float intensity, float tweeningDuration)
    {
        DOTween.To(() => _renderer.material.GetFloat("_Intensity"),
            (x) => _renderer.material.SetFloat("_Intensity", x),
            intensity, tweeningDuration);
    }
}
