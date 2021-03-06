﻿using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnPlayerPaused : MonoBehaviour
{
    public delegate void OnPaused(int playerId);
    public static event OnPaused OnPausedEvent;

    public bool isPaused;
    private int playerId;

    public void Start()
    {
        playerId = -1;
        StartCoroutine(GetID());
    }
    IEnumerator GetID()
    {
        yield return new WaitWhile(() => GetComponent<PlayerPropertiesHolder>() != null);
        playerId = GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
    }

    public void OnPause(InputValue value)
    {
        isPaused = !isPaused;
        if (playerId == -1)
        {
            playerId = GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        }
        OnPausedEvent?.Invoke(playerId);
    }
}
