using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBouncer : MonoBehaviour
{
    public float bounceForce;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb;

        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            rb = collision.gameObject.GetComponent<Rigidbody>();

            foreach (var point in collision.contacts)
            {
                rb.AddForceAtPosition(point.normal * -bounceForce, point.point, ForceMode.Impulse);
            }
        }
    }
}
