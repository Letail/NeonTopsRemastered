using UnityEngine;

public class ManagePlayer : MonoBehaviour
{

    [ContextMenuItem("Enable", "EnableAllChildren")]
    public bool enableThem;
    private void EnableAllChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
