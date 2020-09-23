using UnityEngine;

/// <summary>
/// This object will follow the InterpolatedVisualObject around
/// And indicate which direction the player is holding the right analogue stick
/// </summary>
[RequireComponent(typeof(InterpolatedTransform))]
public class DirectionSphere : MonoBehaviour
{
    public GameObject playerToFollow;
    [HideInInspector]
    public Vector2 directionVector;  //set from SpawnDirSphereOnStart
    [SerializeField]
    private float distanceFromPlayer;

    private void FixedUpdate()
    {
        if(directionVector.magnitude > 0.1)
        {
            transform.position = playerToFollow.transform.position
            + (new Vector3(directionVector.x, 0, directionVector.y).normalized * distanceFromPlayer);
        }
        else
        {
            transform.position = playerToFollow.transform.position;
        }        
    }
}
