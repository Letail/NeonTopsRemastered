using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleOnNavigateMessages : MonoBehaviour
{
    public delegate void OnPlayerNavigate(int playerId, Vector2 navigateValue);
    public static event OnPlayerNavigate OnPlayerNavigateEvent;

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
        if (navigateValue.x > 0.5) navigateValue.x = 1; 
        else navigateValue.x = -1;
        navigateValue.y = 0;

        if (playerId == -1)
        {
            playerId = GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        }

        OnPlayerNavigateEvent?.Invoke(playerId, navigateValue);
        Debug.Log("Navigate Message value = " + navigateValue + "PlayerID : " + playerId);
    }
}