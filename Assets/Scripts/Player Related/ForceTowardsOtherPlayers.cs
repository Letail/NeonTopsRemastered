using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ForceTowardsOtherPlayers : MonoBehaviour
{
    [SerializeField]
    private float forceAmount;
    [SerializeField]
    private float radiusOfInfluence;

    private List<Transform> otherPlayers;
    private Rigidbody rb;
    private Vector3 dirToOtherPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        otherPlayers = new List<Transform>();
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }
    void Update()
    {
        foreach (Transform player in otherPlayers)
        {
            if (Vector3.Distance(player.position, transform.position ) < radiusOfInfluence)
            {
                dirToOtherPlayer = player.position - transform.position;
                rb.AddForce(dirToOtherPlayer * forceAmount, ForceMode.Force);
            }
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        otherPlayers.Add(playerInput.transform);
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        otherPlayers.Remove(playerInput.transform);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusOfInfluence);
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;

    }
}
