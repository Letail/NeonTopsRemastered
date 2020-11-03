using System;
using UnityEngine;

public abstract class SpawnCharacterVisualsPrefab : MonoBehaviour
{
    //public delegate void OnVisualsSpawned(GameObject instance);
    //public static event OnVisualsSpawned OnVisualsSpawnedEvent;

    // The event. Note that by using the generic EventHandler<T> event type
    // we do not need to declare a separate delegate type.
    public static event EventHandler<GameObject> VisualsSpawnedEvent;


    [SerializeField] protected bool spawnOnAwake;    

    [SerializeField] protected GameObject bodyPrefab;
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