using UnityEngine;

public class EnemyInputByBrain : MonoBehaviour
{
    [SerializeField] private PlayersInGame playersInGameSO;
    private bool playersInGameListIsNull;

    [SerializeField]
    private EnemyBrainSO brain;
    public Vector2 moveValue;

    //private List<Transform> players;

    //ChaseAfterPlayers() variables
    private float closestPlayerDistance;
    private float currentDist;
    private Vector3 playerPosToChase;
    private Vector3 directionToChase;

    void Start()
    {
        moveValue = new Vector2(0, 0);
        playersInGameListIsNull = true;

        //players = new List<Transform>();

        //PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        //PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;

        //This is to keep track of players added to the game before this object was loaded
        //foreach (PlayerInput player in playersInGameSO.playerInputs)
        //{
        //    if(player != null) OnPlayerJoined(player);
        //}
    }

    void Update()
    {
        if (playersInGameListIsNull == false)
        {
            if (playersInGameSO.playerSphereTransforms.Count > 0 && brain.chaseAfterPlayers) ChaseAfterPlayers();
            SendMessage("OnMove", moveValue.normalized);
        }
        else
        {
            if (playersInGameSO.playerSphereTransforms != null)
                playersInGameListIsNull = false;
        }
    }

    private void ChaseAfterPlayers()
    {
        closestPlayerDistance = Vector3.Distance(playersInGameSO.playerSphereTransforms[0].position, transform.position);
        playerPosToChase = playersInGameSO.playerSphereTransforms[0].position;

        if (playersInGameSO.playerSphereTransforms.Count > 1)
        {
            for (int i = 1; i < playersInGameSO.playerSphereTransforms.Count; i++)
            {
                currentDist = Vector3.Distance(playersInGameSO.playerSphereTransforms[i].position, transform.position);
                if (currentDist < closestPlayerDistance)
                {
                    closestPlayerDistance = currentDist;
                    playerPosToChase = playersInGameSO.playerSphereTransforms[i].position;
                }
            }
        }
        directionToChase = playerPosToChase - transform.position;
        //directionToChase = transform.position - playerPosToChase;
        moveValue.x = directionToChase.x;
        moveValue.y = directionToChase.z;
    }

    //public void OnPlayerJoined(PlayerInput playerInput)
    //{
    //    players.Add(playerInput.transform);
    //}

    //public void OnPlayerLeft(PlayerInput playerInput)
    //{
    //    players.Remove(playerInput.transform);
    //}

    //private void OnDisable()
    //{
    //    if (PlayerInputManager.instance != null)
    //    {
    //        PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
    //        PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
    //    }
    //}
}
