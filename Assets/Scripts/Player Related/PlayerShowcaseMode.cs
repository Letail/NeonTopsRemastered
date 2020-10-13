using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShowcaseMode : MonoBehaviour
{
    private bool isInShowcaseMode;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private SpawnCharacterVisualsPrefab visualsPrefab;
    private GameObject prefabGameObject;

    public void EnableShowcase()
    {
        if(!isInShowcaseMode)
        {
            isInShowcaseMode = true;
            rb.isKinematic = true;
            playerMovement.enabled = false;
            prefabGameObject = visualsPrefab.GetPrefab();
            prefabGameObject.GetComponent<TrailRenderer>().enabled = false;
            prefabGameObject.GetComponent<Light>().enabled = false;

        }
    }

}
