using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Object List", menuName = "Scriptable Objects/Game Object List")]
public class GameObjectListSO : ScriptableObject
{
    public List<GameObject> list;
}
