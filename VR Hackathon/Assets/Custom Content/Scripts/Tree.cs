using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] CreateFromDisolveHandler[] leaves;
    [SerializeField] Color[] colores;
    [SerializeField] GroundColor groundColor;
    public void TreeEvent()
    {
        StartCoroutine(logEverySecond());
    }
    private IEnumerator logEverySecond()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in leaves)
        {
            int rnd = Random.Range(0, colores.Length);
            if (colores[rnd] != null)
                item.SetColor(colores[rnd]);
            item.ShowObject();
            yield return new WaitForSeconds(0.4f);
        }
        groundColor.ColorGrass();

    }

}
