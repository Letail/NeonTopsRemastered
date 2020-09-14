using UnityEngine;

public class OnPlayerCollFreezeFrame : MonoBehaviour
{
    public delegate void OnPlayerColl();
    public static event OnPlayerColl OnPlayerCollEvent;

    private void OnCollisionEnter(Collision collision)
    {
        OnPlayerCollEvent?.Invoke();
    }

}
