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
    private bool isLooking;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //private void FixedUpdate()
    //{
    //    dashVector = new Vector3(lookInput.normalized.x, 0, lookInput.normalized.y);
    //}

    private void Update()
    {
        isLooking = false;
    }

    private void Dash()
    {
        dashVector = new Vector3(lookInput.normalized.x, 0, lookInput.normalized.y);
        rb.velocity = Vector3.zero;
        rb.AddForce(dashVector * dashStrength);
    }

    /// <summary>
    /// This has to be called from a button! 
    /// It cannot be analogue like the XBox's Bumpers
    /// </summary>
    public void OnDash()
    {
        if (isLooking) Dash();
    }

    public void OnLook(InputValue value)
    {
        ///Using 0.1 has a dead zone, to filter accidental touches or noise
        if(value.Get<Vector2>().magnitude > 0.1f)
        {
            lookInput = value.Get<Vector2>();
            isLooking = true;
        }
        else
        {
            lookInput = Vector2.zero;
            isLooking = false;
        }
    }
}
