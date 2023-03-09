using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressCounter : MonoBehaviour
{
    [SerializeField] public Tree tree;
    private int maxObjectsToColor;
    private int coloredObjectsCounter;

    public static Action<int> CounterUpdated = delegate { };

    private void Start()
    {
        maxObjectsToColor=GameObject.FindObjectsOfType<Colorable>().Length;
    }
    public void UpdateCounter(string eventName)
    {
        coloredObjectsCounter++;
        CounterUpdated.Invoke(coloredObjectsCounter);

        Debug.Log(coloredObjectsCounter + "na" + maxObjectsToColor);
        switch (eventName)
        {
            case "Trunk":
                tree.TreeEvent();
                break;
        }
    }
}
