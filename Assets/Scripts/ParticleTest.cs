using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public GameObject particlePrefab;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
    }
}
