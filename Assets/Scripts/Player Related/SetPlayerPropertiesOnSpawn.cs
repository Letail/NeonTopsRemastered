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
        //TODO: Move the event subscription from here to OnEnable, once the race condition is solved.
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (isPlayerActive1 == false)
        {
            playerInput.gameObject.GetComponent<PlayerPropertiesHolder>().playerProperties = playerProperties1;
            isPlayerActive1 = true;
        }
        else if (isPlayerActive2 == false)
        {
            playerInput.gameObject.GetComponent<PlayerPropertiesHolder>().playerProperties = playerProperties2;
            isPlayerActive2 = true;
        }
        else if (isPlayerActive3 == false)
        {
            playerInput.gameObject.GetComponent<PlayerPropertiesHolder>().playerProperties = playerProperties3;
            isPlayerActive3 = true;
        }
        else if (isPlayerActive4 == false)
        {
            playerInput.gameObject.GetComponent<PlayerPropertiesHolder>().playerProperties = playerProperties4;
            isPlayerActive4 = true;
        }
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        int playerID = playerInput.gameObject.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;

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

    private void OnEnable()
    {
        //TODO: Move the event subscription from Start to here, once the race condition is solved.
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
