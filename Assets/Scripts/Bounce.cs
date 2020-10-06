using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bounce : MonoBehaviour
{
    private Rigidbody rb;
    [Tooltip("Adds Force on OnCollisionEnter")]
    public float bounceForce;
    public float verticalBounceForce;
    public int groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != groundLayer)
        {
            Vector3 bounceBack = transform.position - collision.transform.position;

            foreach (var point in collision.contacts)
            {
                rb.AddForceAtPosition(point.normal * bounceForce, point.point, ForceMode.Impulse);
            }
            rb.AddForce(Vector3.up * verticalBounceForce, ForceMode.Force);
        }
        
    }
}
