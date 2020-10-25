using System.Collections;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public GameObject particlePrefab;
    public float particleLifeTime;
    private GameObject particleObject;
    private ParticleSystem particle;

    private void Start()
    {
        //This prefab instance will be a child of the "Player Holder Prefab"
        particleObject = Instantiate(particlePrefab, Vector3.zero, Quaternion.identity, transform.parent);
        particleObject.name = gameObject.name + "'s " + particleObject.name;
        particle = particleObject.GetComponent<ParticleSystem>();
        particle.Stop(true);
    }

    IEnumerator PlayParticle(Vector3 pos, Vector3 normal, float time)
    {
        particle.transform.position = pos;
        particle.transform.rotation = Quaternion.LookRotation(normal);
        particle.Play(true);
        yield return new WaitForSeconds(time);
        particle.Stop(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 9) // 9 = Ground
        StartCoroutine(PlayParticle(collision.contacts[0].point, collision.contacts[0].normal, particleLifeTime));
    }
}
