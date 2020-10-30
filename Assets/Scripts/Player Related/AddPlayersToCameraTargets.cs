using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayersToCameraTargets : MonoBehaviour
{
    public CameraMultiTarget cameraMultiTarget;
    List<GameObject> targets;
    private GameObject visualsPrefab;

    [Header("Testing Only")]
    public bool SpawnPlayerWhenTheyJoin;

    void Awake()
    {
        targets = new List<GameObject>();
    }

    //public void OnPlayerJoined(PlayerInput playerInput)
    //{
    //    visualsPrefab = playerInput.gameObject.GetComponentInChildren<SpawnCharacterVisualsPrefab>().GetPrefab();
       
    //    if (visualsPrefab != null)
    //    {
    //        targets.Add(visualsPrefab);
    //        cameraMultiTarget.SetTargets(targets.ToArray());
    //    }        
    //}

    public void AddVisualsPrefab(GameObject instance)
    {
        targets.Add(instance);
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        visualsPrefab = playerInput.gameObject.GetComponentInChildren<SpawnCharacterVisualsPrefab>().GetPrefab();
        targets.Remove(visualsPrefab);
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

    private void OnEnable()
    {
        SpawnCharacterVisualsPrefab.OnVisualsSpawnedEvent += AddVisualsPrefab;
        //PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance != null)
        {
            //PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
        }
        SpawnCharacterVisualsPrefab.OnVisualsSpawnedEvent -= AddVisualsPrefab;
    }
}
