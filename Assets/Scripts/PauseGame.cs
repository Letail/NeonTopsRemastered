using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    private float initialTimeScale;
    private int playerWhoPausedId;

    private void Awake()
    {
        isPaused = false;
    }

    private void Start()
    {
        OnPlayerPaused.OnPausedEvent += TogglePause;
    }

    public void TogglePause(int playerId)
    {
        if (!isPaused)
        {
            playerWhoPausedId = playerId;
            initialTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isPaused = true;
            return;
        }
        if (isPaused && playerId == playerWhoPausedId)
        {
            Time.timeScale = initialTimeScale;
            playerWhoPausedId = -1;
            isPaused = false;
            return;
        }        
    }
}
