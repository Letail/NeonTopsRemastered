using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayPlayerScores : MonoBehaviour
{
    [Header("Players Score Displays")]
    [SerializeField]
    private GameObject displayP1;
    [SerializeField]
    private GameObject displayP2;
    [SerializeField]
    private GameObject displayP3;
    [SerializeField]
    private GameObject displayP4;

    private void Awake()
    {
        displayP1.SetActive(false);
        displayP2.SetActive(false);
        displayP3.SetActive(false);
        displayP4.SetActive(false);
    }

    private void Start()
    {
        //TODO: these should be on OnEnable
        OutOfArenaTrigger.OnPlayerOutOfArenaEvent += UpdatePlayerScore;
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;

    }

    void UpdatePlayerScore(Transform trans)
    {

    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        int playerID = playerInput.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        if (playerID == 1)
        {
            displayP1.SetActive(true);

        }
        else if (playerID == 2)
        {
            displayP2.SetActive(true);

        }
        else if (playerID == 3)
        {
            displayP3.SetActive(true);

        }
        else if (playerID == 4)
        {
            displayP3.SetActive(true);

        }
    }
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        int playerID = playerInput.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        if (playerID == 1)
        {
            displayP1.SetActive(false);

        }
        else if (playerID == 2)
        {
            displayP2.SetActive(false);

        }
        else if (playerID == 3)
        {
            displayP3.SetActive(false);

        }
        else if (playerID == 4)
        {
            displayP3.SetActive(false);

        }
    }


    private void OnEnable()
    {


    }
    private void OnDisable()
    {
        OutOfArenaTrigger.OnPlayerOutOfArenaEvent -= UpdatePlayerScore;
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;

        }
    }

}
