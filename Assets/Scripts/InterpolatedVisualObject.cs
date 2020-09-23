using UnityEngine;

/// <summary>
/// This object just follows the actual sphere around.
/// But it's position will be interpolated, hence the RequireComponent script,
/// to make it extra smooth.
/// </summary>
[RequireComponent(typeof(InterpolatedTransform))]
public class InterpolatedVisualObject : MonoBehaviour
{
    [HideInInspector]
    public GameObject objectToFollow; //Needs to be public so that SpawnPlayersVisualsPrefab.cs can access it

    void FixedUpdate()
    {
        transform.position = objectToFollow.transform.position;
        transform.rotation = objectToFollow.transform.rotation;
    }
}
