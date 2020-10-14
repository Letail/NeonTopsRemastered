using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkinSelectionStands : MonoBehaviour
{
    [SerializeField] private List<GameObject> stands;
    private List<SkinHolder> skinHolders;
    [SerializeField] private List<GameObject> modelsPositions;
    //[SerializeField] private List<GameObject> models;


    private List<PlayerInput> playerInputs;

    private bool allHaveDifferentSkins;

    private void Start()
    {
        playerInputs = new List<PlayerInput>();
        skinHolders = new List<SkinHolder>();
        foreach (GameObject item in stands)
        {
            item.SetActive(false);
            skinHolders.Add(item.GetComponent<SkinHolder>());
        }
        PlayerInputManager.instance.onPlayerJoined += ActivateStand;
        PlayerInputManager.instance.onPlayerJoined += TakeControlOfSpawnedPlayer;
        HandleOnNavigateMessages.OnPlayerNavigateEvent += SwitchModel;
    }


    private void TakeControlOfSpawnedPlayer(PlayerInput playerInput)
    {
        playerInputs.Add(playerInput);

        playerInput.GetComponent<PlayerShowcaseMode>().EnableShowcase(hide: true);
        //playerInput.transform.position = modelsPositions[playerInputs.IndexOf(playerInput)].transform.position;
    }

    public void SwitchModel(int playerID, Vector2 navigation)
    {
        skinHolders[playerID].ChangeDisplayedSkin(navigation);
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


    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= ActivateStand;
        PlayerInputManager.instance.onPlayerJoined -= TakeControlOfSpawnedPlayer;
        HandleOnNavigateMessages.OnPlayerNavigateEvent -= SwitchModel;
    }
}
