using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public delegate void OnPlayerScoreUpdated(int playerID, int score);
    public static event OnPlayerScoreUpdated OnPlayerScoreUpdatedEvent;

    [SerializeField]
    private PlayerProperties playerProperties1;
    [SerializeField]
    private PlayerProperties playerProperties2;
    [SerializeField]
    private PlayerProperties playerProperties3;
    [SerializeField]
    private PlayerProperties playerProperties4;
    private List<PlayerProperties> playersPropertiesList;

    private Transform playerTrans1;
    private Transform playerTrans2;
    private Transform playerTrans3;
    private Transform playerTrans4;
    private List<Transform> playersTransList;

    private void Awake()
    {
        playersTransList = new List<Transform> { playerTrans1, playerTrans2, playerTrans3, playerTrans4 };
        playersPropertiesList = new List<PlayerProperties> { playerProperties1, playerProperties2, playerProperties3, playerProperties4 };
    }

    void AddToPlayersDeathCounter(Transform trans)
    {
        //Searching our cash for this transform
        for (int i = 0; i < playersTransList.Count; i++)
        {
            if (playersTransList[i] != null && trans == playersTransList[i])
            {
                playersPropertiesList[i].playerDeaths++;
                OnPlayerScoreUpdatedEvent?.Invoke(i, playersPropertiesList[i].playerDeaths);
                return;
            }
        }

        //Cashing this transform since we didn't find it earlier
        int playerID = trans.GetComponent<PlayerPropertiesHolder>().playerProperties.playerID;
        playersTransList[playerID] = trans;
        playersPropertiesList[playerID].playerDeaths++;

        OnPlayerScoreUpdatedEvent?.Invoke(playerID, playersPropertiesList[playerID].playerDeaths);
    }

    private void OnEnable()
    {
        PlayerInOutOfArenaTrigger.OnPlayerOutOfArenaEvent += AddToPlayersDeathCounter;
    }
    private void OnDisable()
    {
        PlayerInOutOfArenaTrigger.OnPlayerOutOfArenaEvent -= AddToPlayersDeathCounter;
    }

}
