using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuToToggle;
    [SerializeField]
    private GameObject UIBlur;
    private int playerWhoPausedId;

    private void Start()
    {
        OnPlayerPaused.OnPausedEvent += Toggle;
    }

    public void Toggle(int playerId)
    {
        if (menuToToggle.activeSelf == false)
        {
            playerWhoPausedId = playerId;
            menuToToggle.SetActive(true);
            UIBlur.SetActive(true);
            return;
        }
        if (menuToToggle.activeSelf && playerId == playerWhoPausedId)
        {
            playerWhoPausedId = -1;
            menuToToggle.SetActive(false);
            UIBlur.SetActive(false);
            return;
        }
    }

    private void OnDisable()
    {
        OnPlayerPaused.OnPausedEvent -= Toggle;

    }
}
