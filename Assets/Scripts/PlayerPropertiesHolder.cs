using UnityEngine;

public class PlayerPropertiesHolder : MonoBehaviour
{
    public PlayerProperties playerProperties;

    private void Start()
    {
        if(playerProperties == null)
        {
            Debug.LogError("Player doesn't have it's properties set!");
            //throw new System.Exception("Player doesn't have it's properties set!");
        }
    }
}
