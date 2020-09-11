using UnityEngine;

public class SpawnPlayersVisualsPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject playersVisualsPrefab;
    private GameObject prefabInstance;

    public GameObject Spawn()
    {
        prefabInstance = Instantiate(playersVisualsPrefab);
        prefabInstance.GetComponent<InterpolatedVisualObject>().objectToFollow = this.gameObject;

        return prefabInstance;
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}
