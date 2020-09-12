/// Reference on the InputSystem API with SendMessage
/// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.PlayerInput.html?q=SendMessages

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementInput;

    public float maxSpeed;

    [Header("Move with Force")]
    public bool useForce;
    public float speed;

    [Header("Move with Acceleration")]
    public bool useAcceleration;
    public float speedAcc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 movementVector = new Vector3(movementInput.x, 0, movementInput.y);

        if (useForce) MoveWithForce(movementVector);
        if (useAcceleration) MoveWithAcceleration(movementVector);
    }

    private void MoveWithAcceleration(Vector3 movementVector)
    {
        float speedDifference = rb.velocity.magnitude - maxSpeed;
        if (speedDifference > 0)
        {
            rb.AddForce(movementVector * -speedDifference, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(movementVector * speedAcc, ForceMode.Acceleration);
        }
    }

    void MoveWithForce(Vector3 movementVector)
    {
        float speedDifference = rb.velocity.magnitude - maxSpeed;
        if (speedDifference > 0)
        {
            rb.AddForce(movementVector * Time.deltaTime * -speedDifference, ForceMode.Force);
        }
        else
        {
            rb.AddForce(movementVector * Time.deltaTime * speed, ForceMode.Force);
        }
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
