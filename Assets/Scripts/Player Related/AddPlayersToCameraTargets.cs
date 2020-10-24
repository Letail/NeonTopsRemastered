using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayersToCameraTargets : MonoBehaviour
{
    public CameraMultiTarget cameraMultiTarget;
    List<GameObject> targets;
    private GameObject visualsPrefab;

    [Header("Testing Only")]
    public bool SpawnPlayerOnJoined;

    void Awake()
    {
        targets = new List<GameObject>();
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //This if is for testin only.
        //This method should only call GetPrefab(), never Spawn.
        if(SpawnPlayerOnJoined)
        {
            visualsPrefab = playerInput.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().Spawn();
        }
        else
        {
            visualsPrefab = playerInput.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab();
        }

        
        if (visualsPrefab != null)
        {
            targets.Add(visualsPrefab);
            cameraMultiTarget.SetTargets(targets.ToArray());
        }        
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        visualsPrefab = playerInput.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab();
        targets.Remove(visualsPrefab);
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
        }
    }
}
