using UnityEngine;

public class MultipleObjectsToColor : MonoBehaviour
{
    public Renderer[] renderers;
    private void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
    }
    public void ChangeColorsOfThisShaders(float brushPower, Color brushColor)
    {
        foreach (var item in renderers)
        {
            if(item.material.GetColor("_BrushColor") != brushColor)
            {
                item.material.SetFloat("_Intensity",  brushPower);
                item.material.SetColor("_BrushColor", brushColor);
            }
            else
            {
                item.material.SetFloat("_Intensity", item.material.GetFloat("_Intensity") + brushPower);
                item.material.SetColor("_BrushColor", brushColor);
            } 
        }
    }
}
