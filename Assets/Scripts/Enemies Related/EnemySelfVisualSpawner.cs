using UnityEngine;

public class EnemySelfVisualSpawner : MonoBehaviour
{
    [SerializeField]
    private SpawnCharacterVisualsPrefab spawnCharacterVisualsPrefab;

    private void Start()
    {
        spawnCharacterVisualsPrefab.Spawn();
    }
}
