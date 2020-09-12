using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "ScriptableObjects/PlayerProperty")]
public class PlayerProperties : ScriptableObject
{
    public int playerID; //0-indexed
    public int playerDeaths;

}
