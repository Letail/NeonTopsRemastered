using UnityEngine;

public class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    public delegate void OnVisualsSpawned(GameObject instance);
    public static event OnVisualsSpawned OnVisualsSpawnedEvent;

    [SerializeField] private bool alsoSpawnDirSphere;
    [SerializeField] private DirectionSphereSpawnerAndManager directionSphereSpawnerAndManager;

    [SerializeField] private GameObject characterVisualsPrefab;
    private GameObject prefabInstance;

    public GameObject Spawn()
    {
        prefabInstance = Instantiate(characterVisualsPrefab);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        if(alsoSpawnDirSphere)
        {
            directionSphereSpawnerAndManager.SpawnDirSphere(prefabInstance);
        }
        return prefabInstance;
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}
