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
    public float oppositeDirMultiplier;

    [Header("Move with Curve")]
    public AnimationCurve movementCurve;
    public bool moveWithCurve;
    public float moveWithCurveSpeed;
    private float forceBasedOnCurve;
    private float percentageOfMaxSpeed;
    private float angleVelAndInput;


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
        if (moveWithCurve) MoveWithCurve(movementVector);
    }

    private void MoveWithCurve(Vector3 movementVector)
    {
        //float speedDifference = rb.velocity.magnitude - maxSpeed;
        //if (speedDifference > 0)
        //{
        //    rb.AddForce(movementVector * Time.deltaTime * -speedDifference, ForceMode.Force);
        //}
        //else
        //{
        //    percentageOfMaxSpeed = Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
        //    forceBasedOnCurve = Mathf.Lerp(0, moveWithCurveSpeed, movementCurve.Evaluate(percentageOfMaxSpeed));
        //    rb.AddForce(movementVector * Time.deltaTime * forceBasedOnCurve, ForceMode.Force);
        //}

        percentageOfMaxSpeed = Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
        forceBasedOnCurve = Mathf.Lerp(0, moveWithCurveSpeed, movementCurve.Evaluate(percentageOfMaxSpeed));
        rb.AddForce(movementVector * Time.deltaTime * forceBasedOnCurve, ForceMode.Force);
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
        //angleVelAndInput = Mathf.Lerp(oppositeDirMultiplier, 1, Vector3.Angle(movementVector, rb.velocity) / 180f);

        //print("Angle Velocity And Input = " + angleVelAndInput);

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

    public void OnMove(InputValue value) { movementInput = value.Get<Vector2>(); }

    //To be called by the EnemyInputByBrain.cs
    public void OnMove(Vector2 value) { movementInput = value; }
}
