using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUINavigation : EventArgs
{
    public int playerId;
    public Vector2 navigateValue;

    public PlayerUINavigation(int playerId, Vector2 navigateValue)
    {
        this.playerId = playerId;
        this.navigateValue = navigateValue;
    }
}

public class HandleOnNavigateMessages : MonoBehaviour
{
    //public delegate void OnPlayerNavigate(int playerId, Vector2 navigateValue);
    //public static event OnPlayerNavigate OnPlayerNavigateEvent;

    public static event EventHandler<PlayerUINavigation> PlayerNavigateEvent;

    private int playerId;
    private Vector2 navigateValue;

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

    public void OnMove(InputValue value)
    {
        navigateValue = value.Get<Vector2>();

        if (playerId == -1)
        {
            playerId = GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        }

        PlayerNavigateEvent?.Invoke(this, new PlayerUINavigation(playerId, navigateValue));
        //Debug.Log("Navigate Message value = " + navigateValue + "PlayerID: " + playerId);
    }
}