using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressCounter : MonoBehaviour
{
    [SerializeField] public Tree tree;
    private int maxObjectsToColor;
    private int coloredObjectsCounter;
    private void Start()
    {
        maxObjectsToColor=GameObject.FindObjectsOfType<Colorable>().Length;
    }
    public void UpdateCounter(string eventName)
    {
        coloredObjectsCounter++;
        Debug.Log(coloredObjectsCounter + "na" + maxObjectsToColor);
        switch (eventName)
        {
            case "Trunk":
                tree.TreeEvent();
                break;
        }
    }
}
