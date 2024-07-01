using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private Material currentMaterial;
    [HideInInspector] public bool toggle = false;
    public Material highlightMaterial;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = currentMaterial;
    }

    public void MaterialSwap()
    {
        toggle = !toggle;

        if (toggle)
        {
            meshRenderer.material = highlightMaterial;
        } else
        {
            meshRenderer.material = currentMaterial;
        }
    }
}
