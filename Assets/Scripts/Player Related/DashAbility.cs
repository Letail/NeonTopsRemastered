using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class DashAbility : MonoBehaviour
{
    [SerializeField]
    private float dashStrength;

    private Rigidbody rb;
    private Vector3 velocityVector;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dash()
    {
        Debug.Log("Dashed");
        velocityVector = rb.velocity.normalized;
        rb.velocity = Vector3.zero;
        rb.AddForce(velocityVector * dashStrength);
    }

    public void OnDash(Input value)
    {
        Debug.Log("dash type is" + value);
        Dash();
    }
}
