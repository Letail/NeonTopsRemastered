using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class PlayerInOutOfArenaTrigger : MonoBehaviour
{
    //This should go on the arena parent GameObject

    public delegate void OnPlayerOutOfArena(Transform trans);
    public static event OnPlayerOutOfArena OnPlayerOutOfArenaEvent;
    public delegate void OnPlayerInArena(Transform trans);
    public static event OnPlayerInArena OnPlayerInArenaEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInput>() != null) OnPlayerInArenaEvent?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInput>() != null) OnPlayerOutOfArenaEvent?.Invoke(other.transform);
    }
}
