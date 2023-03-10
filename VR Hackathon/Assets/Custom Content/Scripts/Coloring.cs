using UnityEngine;

public class Coloring : MonoBehaviour
{
    [SerializeField] public Renderer brushRenderer;
    [SerializeField] public float brushSize;
    [SerializeField] public float brushPower;

    [SerializeField]
    private AudioClip[] _splatAudios;
    [SerializeField]
    private AudioSource _splatSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Colorable")
        {
            Colorable colorable = other.GetComponent<Colorable>();
            colorable.ChangeColor(brushPower, brushRenderer.material.color, true);
            PlayRandomSplat();
        }

        if (other.tag == "MultipleColorable")
        {
            MultipleObjectsToColor otherScript =
                other.gameObject.GetComponentInParent<MultipleObjectsToColor>();

            if (otherScript != null)
            {
                otherScript.ChangeColorsOfThisShaders(brushPower, brushRenderer.material.color);
                PlayRandomSplat();
            }
        }
    }

    private void PlayRandomSplat()
    {
        int index = Random.Range(0, _splatAudios.Length);
        _splatSource.PlayOneShot(_splatAudios[index]);
    }

}

