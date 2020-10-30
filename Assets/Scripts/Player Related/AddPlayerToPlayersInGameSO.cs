using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayerToPlayersInGameSO : MonoBehaviour
{
    [SerializeField] private PlayersInGame playersInGameSO;

    private void Start()
    {
        if (playersInGameSO.playerInputs == null) playersInGameSO.playerInputs = new List<PlayerInput>();
        if (playersInGameSO.playerSphereTransforms == null) playersInGameSO.playerSphereTransforms = new List<Transform>();

        playersInGameSO.playerInputs.Add(GetComponent<PlayerInput>());
    }

    public void AddPlayerSphereTransform(Transform sphereTransform)
    {
        playersInGameSO.playerSphereTransforms.Add(sphereTransform);
    }

    private void OnDisable()
    {
        playersInGameSO.playerInputs.Clear();
        playersInGameSO.playerSphereTransforms.Clear();
    }

}
