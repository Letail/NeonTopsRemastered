using UnityEngine;

public class SpawnPlayerVisualsPrefabs : SpawnCharacterVisualsPrefab
{
    [SerializeField] private PlayersInGame playersInGameSO;
    [SerializeField] private bool alsoSpawnDirSphere;
    [SerializeField] private DirectionSphereSpawnerAndManager directionSphereSpawnerAndManager;

    [SerializeField] private GameObjectListSO modelsSkinList;

    public override GameObject Spawn()
    {
        //This prefab instance will be a child of the "Player Holder Prefab"

        GameObject skin = modelsSkinList.list[GetComponentInParent<PlayerPropertiesHolder>().playerProperties.skinToUseIndex];

        prefabInstance = Instantiate(skin, transform.parent);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        if (alsoSpawnDirSphere)
        {
            directionSphereSpawnerAndManager.SpawnDirSphere(prefabInstance);
        }

        playersInGameSO.playerVisualsGO.Add(prefabInstance);

        RaiseOnVisualsSpawned(prefabInstance);

        return prefabInstance;
    }
}
