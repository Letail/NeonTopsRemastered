using System;
using UnityEngine;

/// This should go on the arena parent GameObject
[RequireComponent(typeof(Collider))]
public class PlayerInOutOfArenaTrigger : MonoBehaviour
{
    [SerializeField] private PlayersInGame playersInGameSO;

    public static event EventHandler<Transform> PlayerLeftArenaEvent;
    public static event EventHandler<Transform> PlayerEnteredArenaEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (playersInGameSO.playerSphereTransforms != null)
        {
            foreach (var item in playersInGameSO.playerSphereTransforms)
            {
                if (other.transform == item)
                {
                    PlayerEnteredArenaEvent?.Invoke(this, other.transform);
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
                    PlayerLeftArenaEvent?.Invoke(this, other.transform);
                }
            }
        }
    }
}
