using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    private Material skinMaterial;
    public Material SkinMaterial { get => skinMaterial; set => SetSkillMaterial(value); }

    [SerializeField]
    private Renderer modelRenderer;
    [SerializeField]
    private TrailRenderer trail;

    private void SetSkillMaterial(Material mat)
    {
        skinMaterial = mat;
        modelRenderer.material = skinMaterial;
        trail.material.color = skinMaterial.color;
    }
}
