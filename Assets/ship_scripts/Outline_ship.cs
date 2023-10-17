using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_ship : MonoBehaviour
{

    private ship_manager manager;

    public Material outlineMaterial;
    private Material[] defaultMaterial;
    private Renderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<ship_manager>();
        meshRenderer = GetComponent<Renderer>();

        defaultMaterial = meshRenderer.materials;
    }

    // Update is called once per frame
    void Update() {
        if (manager.isSelected) {
            HighlightObject();
        } else {
            UnhighlightObject();
        }
    }

    public void HighlightObject() {

        for(int i = 0; i < meshRenderer.materials.Length; i++) {
            meshRenderer.materials[i] = outlineMaterial;
        }

        meshRenderer.material.SetFloat("_OutlineWidth", 0.005f);
    }

    public void UnhighlightObject() {
        meshRenderer.materials = defaultMaterial;
    }
}
