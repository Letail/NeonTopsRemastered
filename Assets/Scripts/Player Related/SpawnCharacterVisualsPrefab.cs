using UnityEngine;

public class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject characterVisualsPrefab;
    private GameObject prefabInstance;

    public GameObject Spawn()
    {
        prefabInstance = Instantiate(characterVisualsPrefab);
        prefabInstance.GetComponent<CharacterVisualObject>().objectToFollow = this.gameObject;

        return prefabInstance;
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}
