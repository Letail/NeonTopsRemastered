using System;
using UnityEngine;

public abstract class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    // The event. Note that by using the generic EventHandler<T> event type
    // we do not need to declare a separate delegate type.
    public static event EventHandler<GameObject> VisualsSpawnedEvent;

    [SerializeField] protected bool spawnOnAwake;    

    protected GameObject prefabInstance;

    private void Awake()
    {
        if (spawnOnAwake) Spawn();
    }

    public abstract GameObject Spawn();

    protected virtual void RaiseOnVisualsSpawned(GameObject instance)
    {
        VisualsSpawnedEvent?.Invoke(this, instance);
    }

    public GameObject GetPrefab()
    {
        return prefabInstance;
    }
}