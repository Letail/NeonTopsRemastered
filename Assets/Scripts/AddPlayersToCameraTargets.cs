using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayersToCameraTargets : MonoBehaviour
{
    public CameraMultiTarget cameraMultiTarget;
    List<GameObject> targets;

    void Awake()
    {
        targets = new List<GameObject>();
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        targets.Add(playerInput.gameObject);
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        targets.Remove(playerInput.gameObject);
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        if(PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;

        }
    }
}
