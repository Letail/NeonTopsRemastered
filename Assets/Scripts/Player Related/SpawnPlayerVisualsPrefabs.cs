using UnityEngine;

public class SpawnPlayerVisualsPrefabs : SpawnCharacterVisualsPrefab
{
    [SerializeField] private PlayersInGame playersInGameSO;
    [SerializeField] private bool alsoSpawnDirSphere;
    [SerializeField] private DirectionSphereSpawnerAndManager directionSphereSpawnerAndManager;

    public override GameObject Spawn()
    {
        //This prefab instance will be a child of the "Player Holder Prefab"
        prefabInstance = Instantiate(bodyPrefab, transform.parent);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        if (alsoSpawnDirSphere)
        {
            directionSphereSpawnerAndManager.SpawnDirSphere(prefabInstance);
        }

        playersInGameSO.playerVisualsGO.Add(prefabInstance);

        RaiseOnVisuasSpawned(prefabInstance);

        return prefabInstance;
    }
}
