using System.Collections;
using UnityEngine;

public class PlayerShowcaseMode : MonoBehaviour
{
    private bool isInShowcaseMode;

    //[SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SpawnCharacterVisualsPrefab visualsPrefab;
    private GameObject prefabGameObject;
    [SerializeField] private DirectionSphereSpawnerAndManager directionSphere;


    public void EnableShowcase(bool hide)
    {
        if (!isInShowcaseMode)
        {
            StartCoroutine(SafelyEnableShowcase(hide));
        }
    }

    private bool NothingIsNull()
    {
        if (visualsPrefab.GetPrefab() != null && directionSphere.GetPrefab() != null) return true;
        else return false;
    }

    private IEnumerator SafelyEnableShowcase(bool hide)
    {
        Debug.Log("Waiting for everything to initialize");
        yield return new WaitWhile(() => NothingIsNull());

        isInShowcaseMode = true;
        rb.isKinematic = true;
        playerMovement.enabled = false;
        audioSource.enabled = false;
        prefabGameObject = visualsPrefab.GetPrefab();
        prefabGameObject.GetComponent<TrailRenderer>().enabled = false;
        prefabGameObject.GetComponent<Light>().enabled = false;
        if (hide) prefabGameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        directionSphere.GetPrefab().SetActive(false);
    }

}
