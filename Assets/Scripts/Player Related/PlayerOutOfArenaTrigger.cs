using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider))]
public class PlayerOutOfArenaTrigger : MonoBehaviour
{
    //This should go on the arena parent GameObject

    public delegate void OnPlayerOutOfArena(Transform trans);
    public static event OnPlayerOutOfArena OnPlayerOutOfArenaEvent;

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInput>() != null) OnPlayerOutOfArenaEvent?.Invoke(other.transform);
    }
}
