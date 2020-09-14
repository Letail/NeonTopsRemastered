using UnityEngine;

public class OnPlayerCollFreezeFrame : MonoBehaviour
{
    public delegate void OnPlayerColl();
    public static event OnPlayerColl OnPlayerCollEvent;

    private void OnCollisionEnter(Collision collision)
    {
        //Layer 9 is ground
        if(collision.gameObject.layer != 9) OnPlayerCollEvent?.Invoke();
    }

}
