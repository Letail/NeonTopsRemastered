using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// This should go on the arena parent GameObject
[RequireComponent(typeof(Collider))]
public class PlayerInOutOfArenaTrigger : MonoBehaviour
{

    [SerializeField] private PlayersInGame playersInGameSO;

    //public delegate void OnPlayerOutOfArena(Transform trans);
    //public static event OnPlayerOutOfArena OnPlayerOutOfArenaEvent;
    public static event EventHandler<Transform> PlayerLeftArenaEvent;

    //public delegate void OnPlayerInArena(Transform trans);
    //public static event OnPlayerInArena OnPlayerInArenaEvent;
    public static event EventHandler<Transform> PlayerEnteredArenaEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(playersInGameSO.playerSphereTransforms != null)
        {
            foreach (var item in playersInGameSO.playerSphereTransforms)
            {
                if(other.transform == item)
                {
                    //OnPlayerInArenaEvent?.Invoke(other.transform);
                    PlayerLeftArenaEvent?.Invoke(this, other.transform);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playersInGameSO.playerSphereTransforms != null)
        {
            foreach (var item in playersInGameSO.playerSphereTransforms)
            {
                if (other.transform == item)
                {
                    //OnPlayerOutOfArenaEvent?.Invoke(other.transform);
                    PlayerLeftArenaEvent?.Invoke(this, other.transform);
                }
            }
        }
    }
}
