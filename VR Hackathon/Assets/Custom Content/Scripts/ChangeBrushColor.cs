using UnityEngine;

public class ChangeBrushColor : MonoBehaviour
{
    private Renderer renderer;
    [SerializeField]private Coloring coloringScript;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        coloringScript=FindObjectOfType<Coloring>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Marker")
        {
            Renderer _brushRenderer = other.gameObject.GetComponent<Renderer>();
            _brushRenderer.material.color = renderer.material.color;
            coloringScript.brushRenderer = renderer;
        }
    }
}