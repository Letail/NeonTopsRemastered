using System;
using UnityEngine;

public abstract class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    //public delegate void OnVisualsSpawned(GameObject instance);
    //public static event OnVisualsSpawned OnVisualsSpawnedEvent;

    public static event EventHandler<GameObject> VisualsSpawnedEvent;


    [SerializeField] protected bool spawnOnAwake;    

    [SerializeField] protected GameObject bodyPrefab;
    protected GameObject prefabInstance;

    private void Awake()
    {
        if (spawnOnAwake) Spawn();
    }

    public abstract GameObject Spawn();

    protected virtual void RaiseOnVisuasSpawned(GameObject instance)
    {
        VisualsSpawnedEvent?.Invoke(this, instance);
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}