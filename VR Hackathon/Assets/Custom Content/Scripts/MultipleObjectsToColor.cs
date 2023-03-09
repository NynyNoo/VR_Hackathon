using UnityEngine;

public class MultipleObjectsToColor : MonoBehaviour
{
    [SerializeField]
    public Colorable[] Colorables;

    private bool _hasBeenColoredBefore;

    private GameProgressCounter _progressCounter;

    private void Start()
    {
        _progressCounter = GameObject.FindObjectOfType<GameProgressCounter>();
    }

    public void ChangeColorsOfThisShaders(float brushPower, Color brushColor)
    {
        if(_hasBeenColoredBefore == false)
        {
            _progressCounter.UpdateCounter(gameObject.name);
        }

        foreach(var colorable in Colorables)
        {
            colorable.ChangeColor(brushPower, brushColor, false);
        }

        _hasBeenColoredBefore = true;
    }
}
