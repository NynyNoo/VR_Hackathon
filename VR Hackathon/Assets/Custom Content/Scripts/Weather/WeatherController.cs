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

    private Material _currentSkybox;

    private void Awake()
    {
        GameProgressCounter.CounterUpdated += HandleCounterUpdate;
        _currentSkybox = RenderSettings.skybox;

        ResetWeather();
    }

    private void HandleCounterUpdate(int progress)
    {
        if(progress > _progressTresholdForSkyboxChange)
        {
            ChangeWeatherToDay();
        }
    }

    private void ChangeWeatherToDay()
    {
        CopyShaderColorParameter(_daySkyboxTemplate, _currentSkybox,"_SkyGradientTop");
    }

    private void CopyShaderColorParameter(Material from, Material to,string name)
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
