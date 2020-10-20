using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeepPlayersInputReference : MonoBehaviour
{
    [SerializeField]
    private PlayersInGame playersInGameSO;

    void Start()
    {
        if(playersInGameSO.playerInputs == null)
        {
            playersInGameSO.playerInputs = new List<PlayerInput>();
        }
        playersInGameSO.playerInputs.Clear();

        PlayerInputManager.instance.onPlayerJoined += AddPlayerInputToList;
        PlayerInputManager.instance.onPlayerLeft += RemovePlayerInputToList;
    }

    public void AddPlayerInputToList(PlayerInput playerInput)
    {
        playersInGameSO.playerInputs.Add(playerInput);
        Debug.Log("This was added: " + playersInGameSO.playerInputs[playersInGameSO.playerInputs.Count - 1]);
    }
    public void RemovePlayerInputToList(PlayerInput playerInput)
    {
        if (playersInGameSO.playerInputs.Contains(playerInput))
        {
            playersInGameSO.playerInputs.Remove(playerInput);
        }
    }


    private void OnDisable()
    {
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= AddPlayerInputToList;
            PlayerInputManager.instance.onPlayerLeft -= RemovePlayerInputToList;
        }
        playersInGameSO.playerInputs.Clear();
    }
}
