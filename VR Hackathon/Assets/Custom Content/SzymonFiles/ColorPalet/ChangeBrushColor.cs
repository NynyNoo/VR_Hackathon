using UnityEngine;

public class ChangeBrushColor : MonoBehaviour
{
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Marker")
            other.gameObject.GetComponent<Renderer>().material.color = renderer.material.color;
    }
}