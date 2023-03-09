using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField]
    private Material _daySkyboxTemplate;
    [SerializeField]
    private Material _nightSkyboxTemplate;
    [SerializeField]
    private int _progressTresholdForSkyboxChange = 50;
    [SerializeField]
    private Transform _directionalLight;
    [SerializeField]
    private float _lightXRotationWhenSunUp = 15f;
    [SerializeField]
    private float _sunRisingTime = 5f;

    private Material _currentSkybox;

    private void Awake()
    {
        GameProgressCounter.CounterUpdated += HandleCounterUpdate;
        _currentSkybox = RenderSettings.skybox;

        ResetWeather();
    }

    private void HandleCounterUpdate(int progress)
    {
        if (progress > _progressTresholdForSkyboxChange)
        {
            ChangeWeatherToDay();
            ChangeSunPosition();
        }
    }

    private void ChangeSunPosition()
    {
        float y = _directionalLight.transform.rotation.eulerAngles.y;

        _directionalLight.DORotate(
            new Vector3(_lightXRotationWhenSunUp,
            y, 0f), _sunRisingTime);
    }

    private void ChangeWeatherToDay()
    {
        CopyShaderColorParameter(_daySkyboxTemplate, _currentSkybox, "_SkyGradientTop");
    }

    private void CopyShaderColorParameter(Material from, Material to, string name)
    {
        Color colorToCopy = from.GetColor(name);
        to.SetColor(name, colorToCopy);
    }

    private void ResetWeather()
    {
        CopyShaderColorParameter(_nightSkyboxTemplate, _currentSkybox, "_SkyGradientTop");
    }

    private void OnApplicationQuit()
    {
        ResetWeather();
    }
}
