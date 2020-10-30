using UnityEngine;

[CreateAssetMenu(fileName = "Player Properties", menuName = "Scriptable Objects/Player Property")]
public class PlayerProperties : ScriptableObject
{
    public int playerID; //0-indexed
    public int playerDeaths;

}
