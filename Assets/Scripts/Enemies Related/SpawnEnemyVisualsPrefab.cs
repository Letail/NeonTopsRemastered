using UnityEngine;

public class SpawnEnemyVisualsPrefab : SpawnCharacterVisualsPrefab
{
    [SerializeField] private GameObject bodyPrefab;

    public override GameObject Spawn()
    {
        //This prefab instance will be a child of the "Player Holder Prefab"
        prefabInstance = Instantiate(bodyPrefab, transform.parent);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        return prefabInstance;
    }
}
