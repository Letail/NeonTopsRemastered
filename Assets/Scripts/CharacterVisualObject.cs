using UnityEngine;

/// <summary>
/// This object just follows the actual sphere around.
/// But it's position will be interpolated, hence the RequireComponent script,
/// to make it extra smooth.
/// </summary>
[RequireComponent(typeof(InterpolatedTransform))]
public class CharacterVisualObject : MonoBehaviour
{
    [HideInInspector]
    public GameObject objectToFollow; //Needs to be public so that SpawnPlayersVisualsPrefab.cs can access it
    private Rigidbody rb;
    private Vector3 vel;
    [SerializeField]
    private float tiltStrength;

    private void Start()
    {
        rb = objectToFollow.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position = objectToFollow.transform.position;
        vel.x = rb.velocity.z * tiltStrength;
        vel.z = - rb.velocity.x * tiltStrength;
        transform.rotation = Quaternion.Euler(vel);
    }
}
