using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerSkinSelectionStands : MonoBehaviour
{
    [Header("Player Ready Text & Color")]
    [SerializeField] [Multiline] private string notReadyText;
    [SerializeField] [Multiline] private string readyText;
    [SerializeField] private Color notReadyColor;
    [SerializeField] private Color readyColor;

    [Header("Everyone Ready Countdown")]
    [SerializeField] private float countDownTime;
    [SerializeField] private Slider countDownSlider;


    [Header("Objects")]
    [SerializeField] private List<GameObject> stands;
    [SerializeField] private List<TMP_Text> standsText;

    private List<SkinHolder> skinHolders;
    [SerializeField] private List<GameObject> modelsPositions;

    [Header("Scenes Indexes")]
    [SerializeField] private int multiplayerSceneIndex;

    private List<bool> playersReadyState;
    private List<int> playersSkinChosenIndex;
    private List<int> skinIndexChecked;

    private List<PlayerInput> playerInputs;

    private bool allHaveDifferentSkins;
    private bool quitCountDown;

    private Coroutine countDownCoroutine;

    private void Start()
    {
        allHaveDifferentSkins = false;

        //Initializing Lists
        playersReadyState = new List<bool>();
        playersSkinChosenIndex = new List<int>();
        skinIndexChecked = new List<int>();
        playerInputs = new List<PlayerInput>();
        skinHolders = new List<SkinHolder>();

        //Editing the Text on the Stands
        for (int i = 0; i < standsText.Count; i++)
        {
            standsText[i].text = string.Format(notReadyText, i + 1);
        }

        foreach (GameObject item in stands)
        {
            item.SetActive(false);
            skinHolders.Add(item.GetComponent<SkinHolder>());
        }

        //Subscribing to Events
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        HandleOnNavigateMessages.OnPlayerNavigateEvent += SwitchModel;
        OnPlayerPaused.OnPausedEvent += LockChoice;
    }


    private void OnPlayerJoined(PlayerInput playerInput)
    {
        ActivateStand(playerInput);
        TakeControlOfSpawnedPlayer(playerInput);

        playersReadyState.Add(false);
        playersSkinChosenIndex.Add(0); //They all start at index 0.

    }

    private void TakeControlOfSpawnedPlayer(PlayerInput playerInput)
    {
        playerInputs.Add(playerInput);

        playerInput.GetComponent<PlayerShowcaseMode>().EnableShowcase(hide: true);
        //playerInput.transform.position = modelsPositions[playerInputs.IndexOf(playerInput)].transform.position;
    }

    public void SwitchModel(int playerID, Vector2 navigation)
    {
        //ChangeDisplayedSkin() will return the index of the current skin chosen.
        playersSkinChosenIndex[playerID] = skinHolders[playerID].ChangeDisplayedSkin(navigation);
    }


    void LockChoice(int playerId)
    {
        if (playersReadyState[playerId] == false && CheckIfAllHaveDifferentSkins())
        {
            standsText[playerId].color = readyColor;
            standsText[playerId].text = string.Format(readyText, playerId + 1);
            playersReadyState[playerId] = true;

            //If everyone has finished choosing, we can finish the skin selection.
            if(CheckIfEveryoneIsReady() && CheckIfAllHaveDifferentSkins()) FinishSkinSelection();
        }
        else
        {
            standsText[playerId].color = notReadyColor;
            standsText[playerId].text = string.Format(notReadyText, playerId + 1);
            playersReadyState[playerId] = false;
            StopCountDown();
        }
    }

    private bool CheckIfEveryoneIsReady()
    {
        foreach (var item in playersReadyState)
        {
            if (item == false)
            {
                StopCountDown();
                return false; //if one player is not ready, then not everyone is ready
            }
        }        
        return true;
    }

    private bool CheckIfAllHaveDifferentSkins()
    {
        skinIndexChecked.Clear();

        //We don't need to check if the first player has the same
        //skin index as anyone else, since they are the first to be checked.
        skinIndexChecked.Add(playersSkinChosenIndex[0]);

        for (int i = 1; i < playersSkinChosenIndex.Count; i++)
        {
            if(skinIndexChecked.Contains(playersSkinChosenIndex[i]))
            {
                //The skinIndexChecked already contained this value,
                //so it means two players have chosen the same skin index.
                return false;
            }
            else
            {
                skinIndexChecked.Add(playersSkinChosenIndex[i]);
            }
        }
        //If the for loop never returns false, then that means they all
        //have different skin indexes and we can return true.
        allHaveDifferentSkins = true;
        return true;
    }

    private void ActivateStand(PlayerInput playerInput)
    {
        foreach (GameObject item in stands)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
                return;
            }
        }
    }

    private void FinishSkinSelection()
    {
        if(countDownCoroutine != null) StopCoroutine(countDownCoroutine);
        countDownCoroutine = StartCoroutine(CountDownStart(countDownTime));
    }

    private void StopCountDown()
    {
        if (countDownCoroutine != null) StopCoroutine(countDownCoroutine);
        countDownSlider.gameObject.SetActive(false);
    }

    private IEnumerator CountDownStart(float waitTime)
    {
        if(waitTime == 0) Debug.LogError("waitTime cannot be zero");
        countDownSlider.gameObject.SetActive(true);
        float counter = 0;
        while(counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            countDownSlider.value = counter / waitTime;

            yield return null;
        }
        countDownSlider.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(multiplayerSceneIndex); //Load main multiplayer scene. TEMPORARY LOCATION FOR THIS CODE
    }

    private void OnDisable()
    {
        if(PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= ActivateStand;
            PlayerInputManager.instance.onPlayerJoined -= TakeControlOfSpawnedPlayer;
        }
        HandleOnNavigateMessages.OnPlayerNavigateEvent -= SwitchModel;
    }
}
