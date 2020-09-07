using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowPlayer : MonoBehaviour
{
    public Transform playerSphere;
    private Vector3 offset;

    void Start()
    {
        offset = playerSphere.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerSphere.transform.position + offset;
    }
}
