using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperEffects : MonoBehaviour
{
    public GameObject bumperRing;
    public float colourChangeTime;
    public Color colorToChangeTo;

    private Material bumperRingMaterial;
    private Color initialBumperRingColor;

    private void Awake()
    {
        bumperRingMaterial = bumperRing.GetComponent<Renderer>().material;
        initialBumperRingColor = bumperRingMaterial.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AnimateRing();
    }

    private void AnimateRing()
    {
        StartCoroutine(ColourChange());

    }

    IEnumerator ColourChange()
    {
        bumperRingMaterial.SetColor("_BaseColor", colorToChangeTo);

        yield return new WaitForSeconds(colourChangeTime);

        bumperRingMaterial.SetColor("_BaseColor", initialBumperRingColor);

    }
}
