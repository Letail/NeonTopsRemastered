using UnityEditor;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    [SerializeField] private Vector3 startingPosition;
    public AddPlayerToPlayersInGameSO addPlayerToPlayersInGameSO;

    [ContextMenu("EnableAllChildren")]
    private void EnableAllChildren()
    {
        if (EditorApplication.isPlaying)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                if (child.GetComponent<PlayerMovement>() != null) 
                    addPlayerToPlayersInGameSO.AddPlayerSphereTransform(child.transform);
            }
            foreach (Transform child in transform)
            {
                child.gameObject.transform.position = startingPosition;
            }
        }
    }
}
