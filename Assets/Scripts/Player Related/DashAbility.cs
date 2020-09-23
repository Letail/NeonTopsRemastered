using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class DashAbility : MonoBehaviour
{
    [SerializeField]
    private float dashStrength;

    private Rigidbody rb;
    private Vector3 dashVector;
    private Vector2 lookInput;
    private Transform dirSphere;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        dashVector = new Vector3(lookInput.normalized.x, 0, lookInput.normalized.y);
    }

    void Dash()
    {
        dashVector = new Vector3(lookInput.normalized.x, 0, lookInput.normalized.y);
        rb.velocity = Vector3.zero;
        rb.AddForce(dashVector * dashStrength);
    }

    public void OnDash()
    {
        //This has to be called from a button! 
        //It cannot be analogue like the XBox's Bumpers
        Dash();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
