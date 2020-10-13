using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkinSelectionStands : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> stands;
    [SerializeField]
    private List<GameObject> modelsPositions;

    private List<PlayerInput> playerInputs;

    private bool allHaveDifferentSkins;

    private void Start()
    {
        playerInputs = new List<PlayerInput>();
        foreach (var item in stands)
        {
            item.SetActive(false);
        }
        PlayerInputManager.instance.onPlayerJoined += ActivateStand;
        PlayerInputManager.instance.onPlayerJoined += TakeControlOfSpawnedPlayer;
    }


    private void TakeControlOfSpawnedPlayer(PlayerInput playerInput)
    {
        playerInputs.Add(playerInput);

        //foreach (var item in playerInput.GetComponents(typeof(Component)))
        //{
        //    Debug.Log(item.GetType());
        //}

        playerInput.GetComponent<Rigidbody>().isKinematic = true;
        playerInput.GetComponent<PlayerMovement>().enabled = false;

        playerInput.transform.position = modelsPositions[playerInputs.IndexOf(playerInput)].transform.position;
        playerInput.transform.localScale = Vector3.one;
        playerInput.GetComponent<PlayerShowcaseMode>().EnableShowcase();


    }

    private void ActivateStand(PlayerInput playerInput)
    {
        foreach (var item in stands)
        {
            if(item.activeSelf == false)
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
    }


}
