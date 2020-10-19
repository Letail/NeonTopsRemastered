using UnityEngine;
using UnityEngine.InputSystem;

public class RepositionPlayerOnSpawn : MonoBehaviour
{
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private Vector3 position;

    void Start()
    {
        inputManager.onPlayerJoined += Reposition;
    }


    void Reposition(PlayerInput playerInput)
    {
        playerInput.transform.position = position;
    }

    private void OnDisable()
    {
        inputManager.onPlayerJoined -= Reposition;
    }
}
