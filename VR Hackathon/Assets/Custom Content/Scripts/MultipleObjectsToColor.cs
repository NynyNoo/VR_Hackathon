using UnityEngine;

public class MultipleObjectsToColor : MonoBehaviour
{
    [SerializeField]
    public Colorable[] Colorables;

    private void Start()
    {
        //Colorables = gameObject.GetComponentsInChildren<Colorable>();
    }
    public void ChangeColorsOfThisShaders(float brushPower, Color brushColor)
    {
        foreach(var colorable in Colorables)
        {
            colorable.ChangeColor(brushPower, brushColor);
        }

        //foreach (var item in renderers)
        //{
        //    if(item.gameObject.tag == "Glass")
        //    {
        //        continue;
        //    }

        //    if(item.material.GetColor("_BrushColor") != brushColor)
        //    {
        //        item.material.SetFloat("_Intensity",  brushPower);
        //        item.material.SetColor("_BrushColor", brushColor);
        //    }
        //    else
        //    {
        //        item.material.SetFloat("_Intensity", item.material.GetFloat("_Intensity") + brushPower);
        //        item.material.SetColor("_BrushColor", brushColor);
        //    } 
        //}
    }
}
