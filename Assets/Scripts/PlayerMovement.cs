using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    //Input Actions
    private PlayerInputActions inputAction;
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
        inputAction = new PlayerInputActions();
        inputAction.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }
    void Update()
    {
        //Read Value
        Vector3 movementVector = new Vector3(movementInput.x, 0, movementInput.y);
        //Move Player

        if(useForce) MoveWithForce(movementVector);
        if(useAcceleration) MoveWithAcceleration(movementVector);
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
            rb.AddForce(movementVector * -speedDifference, ForceMode.Force);
        }
        else
        {
            rb.AddForce(movementVector * speed, ForceMode.Force);
        }
    }


    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
}
