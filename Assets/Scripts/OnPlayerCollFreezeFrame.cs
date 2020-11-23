using System;
using UnityEngine;

public class OnPlayerCollFreezeFrame : MonoBehaviour
{
    public static event EventHandler OnPlayerCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        //Layer 9 is ground
        if(collision.gameObject.layer != 9) OnPlayerCollisionEvent?.Invoke(this, null);
    }

}
