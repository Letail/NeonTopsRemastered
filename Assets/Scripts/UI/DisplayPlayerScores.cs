using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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
    private List<GameObject> displaysList;


    [Header("Displays Text")]
    [SerializeField]
    private TMP_Text textP1;
    [SerializeField]
    private TMP_Text textP2;
    [SerializeField]
    private TMP_Text textP3;
    [SerializeField]
    private TMP_Text textP4;
    private List<TMP_Text> textsList;

    private readonly string scoreText = "Player {0} Deaths: {1}";

    private void Awake()
    {
        displaysList = new List<GameObject> { displayP1, displayP2, displayP3, displayP4 };
        textsList = new List<TMP_Text> { textP1, textP2, textP3, textP4 };

        foreach (var item in displaysList)
        {
            item.SetActive(false);
        }
    }

    private void Start()
    {
        //TODO: these should be on OnEnable
        ScoreManager.OnPlayerScoreUpdatedEvent += UpdatePlayerScore;
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;

        UpdatePlayerScore(0, 0);
        UpdatePlayerScore(1, 0);
        UpdatePlayerScore(2, 0);
        UpdatePlayerScore(3, 0);

    }

    void UpdatePlayerScore(int playerID, int score)
    {
        textsList[playerID].text = string.Format(scoreText, playerID, score);
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        int playerID = playerInput.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;

        displaysList[playerID].SetActive(true);
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        int playerID = playerInput.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        displaysList[playerID].SetActive(false);
    }


    private void OnEnable()
    {


    }
    private void OnDisable()
    {
        ScoreManager.OnPlayerScoreUpdatedEvent -= UpdatePlayerScore;
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;

        }
    }

}
