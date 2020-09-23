using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

/// <summary>
/// This is to be attached to the player prefab
/// </summary>
public class SpawnDirSphereOnStart : MonoBehaviour
{
    [SerializeField]
    private GameObject directionSpherePrefab;
    private GameObject dirSphereObject;
    private DirectionSphere directionSphere;
    private bool directionSphereIsSet = false;

    private Vector2 lookInput;

    void Start()
    {
        dirSphereObject = Instantiate(directionSpherePrefab, this.transform.position, Quaternion.identity);
        directionSphere = dirSphereObject.GetComponent<DirectionSphere>();
        directionSphere.playerToFollow = GetComponent<SpawnPlayersVisualsPrefab>().GetPrefab();
        directionSphereIsSet = true;
    }

    public void OnLook(InputValue value)
    {
        if (directionSphereIsSet)
        {
            lookInput = value.Get<Vector2>();
            directionSphere.directionVector = lookInput;
        }

    }
}
