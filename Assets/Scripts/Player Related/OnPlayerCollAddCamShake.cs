﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class OnPlayerCollAddCamShake : MonoBehaviour
{
    public delegate void OnPlayerColl(float traumaAmount);
    public static event OnPlayerColl OnPlayerCollEvent;

    [SerializeField]
    [Range(0, 1)]
    private float traumaAmout;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 9)
        {
            //Debug.Log("Player Collision");
            OnPlayerCollEvent?.Invoke(traumaAmout);
        }
    }
}