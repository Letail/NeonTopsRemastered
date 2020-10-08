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
        try
        {
            playerId = GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        }
        catch (System.Exception)
        {

        }
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
