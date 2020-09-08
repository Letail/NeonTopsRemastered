using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayersToCameraTargets : MonoBehaviour
{
    public CameraMultiTarget cameraMultiTarget;
    List<GameObject> targets;

    void Start()
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
}
