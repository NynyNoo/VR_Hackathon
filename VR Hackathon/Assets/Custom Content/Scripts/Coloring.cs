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
            Colorable colorable = other.GetComponent<Colorable>();
            colorable.ChangeColor(brushPower, brushRenderer.material.color, true);
        }

        if (other.tag == "MultipleColorable")
        {
            MultipleObjectsToColor otherScript =
                other.gameObject.GetComponentInParent<MultipleObjectsToColor>();

            if (otherScript != null)
            {
                otherScript.ChangeColorsOfThisShaders(brushPower, brushRenderer.material.color);
            }
        }
    }

}

