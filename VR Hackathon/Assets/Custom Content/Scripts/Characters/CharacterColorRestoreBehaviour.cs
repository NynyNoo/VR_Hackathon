using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorRestoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _restorationStatusTreshold = 0.6f;
    [SerializeField]
    private ParticleSystem _inkDrops;

    public bool IsColorRestored;
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

        if(intensity >= _restorationStatusTreshold)
        {
            IsColorRestored = true;
            DisableInkDrops();
        }
    }

    private void DisableInkDrops()
    {
        _inkDrops.Stop();
    }
}
