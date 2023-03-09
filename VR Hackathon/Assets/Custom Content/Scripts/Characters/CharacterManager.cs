using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Renderer[] _characterRenderers;

    private float _passedTime;

    private void Start()
    {
        _characterRenderers = GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        if (_passedTime > 5f)
        {
            RestoreColorToCharacters();
        }

        _passedTime += Time.deltaTime;
    }

    private void RestoreColorToCharacters()
    {
        for (int i = 0; i < _characterRenderers.Length; i++)
        {
            _characterRenderers[i].material.SetFloat("_Intensity", 100f);
        }
    }
}
