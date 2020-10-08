using UnityEngine;

public class PlayerPropertiesHolder : MonoBehaviour
{
    ///These properties are to be set by SetPlayersPropertiesOnSpawn.cs
    ///They're supposed to be left unassigned, since they will be different
    ///depending on which person is controlling this player character
    [HideInInspector]
    public PlayerProperties playerProperties;

    private void Start()
    {
        if(playerProperties == null) Debug.LogError("Player doesn't have its properties set!");
    }
}
