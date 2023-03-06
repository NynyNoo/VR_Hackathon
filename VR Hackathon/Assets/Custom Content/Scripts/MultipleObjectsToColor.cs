using UnityEngine;

public class MultipleObjectsToColor : MonoBehaviour
{
    [SerializeField]
    public Colorable[] Colorables;

    public void ChangeColorsOfThisShaders(float brushPower, Color brushColor)
    {
        foreach(var colorable in Colorables)
        {
            colorable.ChangeColor(brushPower, brushColor);
        }
    }
}
