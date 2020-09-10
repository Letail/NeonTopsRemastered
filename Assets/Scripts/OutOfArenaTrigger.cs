using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OutOfArenaTrigger : MonoBehaviour
{
    public delegate void OnPlayerOutOfArena(Transform trans);
    public event OnPlayerOutOfArena OnPlayerOutOfArenaEvent;

    private void Awake()
    {
        OnPlayerOutOfArenaEvent += PlayerLeftArena;
    }

    private void OnTriggerExit(Collider other)
    {
        OnPlayerOutOfArenaEvent?.Invoke(other.transform);
    }

    private void PlayerLeftArena(Transform playerTrans)
    {
        Debug.Log("Player " + playerTrans.name + " left arena");
    }

}
