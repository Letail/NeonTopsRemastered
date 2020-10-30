using UnityEngine;

public class EnablePlayerSphere : MonoBehaviour
{
    public GameObject playerSphere;

    [ContextMenu("Enable")]
    private void Enable()
    {
        playerSphere.SetActive(true);
    }
}
