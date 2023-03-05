using UnityEngine;

public class Coloring : MonoBehaviour
{
    [SerializeField] public Renderer brushRenderer;
    [SerializeField] public float brushSize;
    [SerializeField] public float brushPower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Colorable")
        {
            Renderer rendererToPaint = other.GetComponent<Renderer>();
            if (rendererToPaint.material.GetColor("_BrushColor") != brushRenderer.material.color)
            {
                Debug.Log("-");
                rendererToPaint.material.SetFloat("_Intensity", brushPower);
                rendererToPaint.material.SetColor("_BrushColor", brushRenderer.material.color);
            }
            else 
            {
                Debug.Log("+");
                rendererToPaint.material.SetFloat("_Intensity", rendererToPaint.material.GetFloat("_Intensity") + brushPower);
                rendererToPaint.material.SetFloat("_Intensity", rendererToPaint.material.GetFloat("_Intensity") + brushPower);
            }
        }
    }

}

