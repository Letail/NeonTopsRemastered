using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class SetPlayerPropertiesOnSpawn : MonoBehaviour
{
    [SerializeField]
    private PlayerProperties playerProperties1;
    [SerializeField]
    private PlayerProperties playerProperties2;
    [SerializeField]
    private PlayerProperties playerProperties3;
    [SerializeField]
    private PlayerProperties playerProperties4;

    private bool isPlayerActive1;
    private bool isPlayerActive2;
    private bool isPlayerActive3;
    private bool isPlayerActive4;

    void Awake()
    {
        isPlayerActive1 = isPlayerActive2 = isPlayerActive3 = isPlayerActive4 = false;

    }

    private void Start()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (isPlayerActive1 == false)
        {
            //Debug.Log("Player Properties 1 added!");

            playerInput.gameObject.GetComponentInChildren<PlayerPropertiesHolder>().playerProperties = playerProperties1;
            isPlayerActive1 = true;
        }
        else if (isPlayerActive2 == false)
        {
            //Debug.Log("Player Properties 2 added!");
            playerInput.gameObject.GetComponentInChildren<PlayerPropertiesHolder>().playerProperties = playerProperties2;
            isPlayerActive2 = true;
        }
        else if (isPlayerActive3 == false)
        {
            //Debug.Log("Player Properties 3 added!");
            playerInput.gameObject.GetComponentInChildren<PlayerPropertiesHolder>().playerProperties = playerProperties3;
            isPlayerActive3 = true;
        }
        else if (isPlayerActive4 == false)
        {
            //Debug.Log("Player Properties 4 added!");
            playerInput.gameObject.GetComponentInChildren<PlayerPropertiesHolder>().playerProperties = playerProperties4;
            isPlayerActive4 = true;
        }
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        int playerID = playerInput.gameObject.GetComponentInChildren<PlayerPropertiesHolder>().playerProperties.playerID;

        if (playerID == 1)
        {
            isPlayerActive1 = false;
        }
        if (playerID == 2)
        {
            isPlayerActive2 = false;
        }
        if (playerID == 3)
        {
            isPlayerActive3 = false;
        }
        if (playerID == 4)
        {
            isPlayerActive4 = false;
        }
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;

        }
    }
}
