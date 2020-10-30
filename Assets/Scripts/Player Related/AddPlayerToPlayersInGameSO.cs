using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddPlayerToPlayersInGameSO : MonoBehaviour
{
    [SerializeField] private PlayersInGame playersInGameSO;

    private void Start()
    {
        InitializeLists();
        ClearLists();

        playersInGameSO.playerInputs.Add(GetComponent<PlayerInput>());
    }

    private void InitializeLists()
    {
        if (playersInGameSO.playerInputs == null) playersInGameSO.playerInputs = new List<PlayerInput>();
        if (playersInGameSO.playerSphereTransforms == null) playersInGameSO.playerSphereTransforms = new List<Transform>();
        if (playersInGameSO.playerVisualsGO == null) playersInGameSO.playerVisualsGO = new List<GameObject>();        
    }

    private void ClearLists()
    {
        playersInGameSO.playerInputs.Clear();
        playersInGameSO.playerSphereTransforms.Clear();
        playersInGameSO.playerVisualsGO.Clear();
    }

    public void AddPlayerSphereTransform(Transform sphereTransform)
    {
        playersInGameSO.playerSphereTransforms.Add(sphereTransform);
    }

    private void OnDisable()
    {
        ClearLists();
    }
}
