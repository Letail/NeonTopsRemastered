using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayersInGame", menuName = "Scriptable Objects/PlayersInGame")]
public class PlayersInGame : ScriptableObject
{
    public List<PlayerInput> playerInputs;
}
