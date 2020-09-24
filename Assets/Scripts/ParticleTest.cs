using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class ParticleTest : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject particle;
    public float particleLifeTime;

    private void Start()
    {
        particle = Instantiate(particlePrefab, transform, false);
        particle.SetActive(false);
    }

    IEnumerator PlayParticle(Vector3 pos, float time)
    {
        particle.transform.position = pos;
        particle.SetActive(true);
        yield return new WaitForSeconds(time);
        particle.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(PlayParticle(collision.contacts[0].point, particleLifeTime));
    }
}
