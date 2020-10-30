using UnityEngine;

public class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    public delegate void OnVisualsSpawned(GameObject instance);
    public static event OnVisualsSpawned OnVisualsSpawnedEvent;

    [SerializeField] private bool spawnOnAwake;
    [SerializeField] private bool alsoSpawnDirSphere;
    [SerializeField] private DirectionSphereSpawnerAndManager directionSphereSpawnerAndManager;

    [SerializeField] private GameObject characterVisualsPrefab;
    private GameObject prefabInstance;

    private void Awake()
    {
        if (spawnOnAwake) Spawn();
    }

    public GameObject Spawn()
    {
        //This prefab instance will be a child of the "Player Holder Prefab"
        prefabInstance = Instantiate(characterVisualsPrefab, transform.parent);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        if(alsoSpawnDirSphere)
        {
            directionSphereSpawnerAndManager.SpawnDirSphere(prefabInstance);
        }

        OnVisualsSpawnedEvent?.Invoke(prefabInstance);

        return prefabInstance;
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}
