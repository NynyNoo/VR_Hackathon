using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField]
    private Material _currentSkybox;
    [SerializeField]
    private Material _daySkyboxTemplate;
    [SerializeField]
    private int _progressTresholdForSkyboxChange;

    private void Start()
    {
        GameProgressCounter.CounterUpdated += HandleCounterUpdate;
    }

    private void HandleCounterUpdate(int progress)
    {
        if(progress > _progressTresholdForSkyboxChange)
        {
            ChangeSkyboxParameters();
        }
    }

    private void ChangeSkyboxParameters()
    {

    }
}
