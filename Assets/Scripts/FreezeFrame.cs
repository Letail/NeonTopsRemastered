using System;
using System.Collections;
using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float freezeDuration;
    private bool isFrozen;
    private float originalTimeScale;

    private void Awake()
    {
        isFrozen = false;
        OnPlayerCollFreezeFrame.OnPlayerCollisionEvent += Freeze;
    }
    public void Freeze(object sender, EventArgs e)
    {
        if (isFrozen == false) StartCoroutine(DoFreeze());
    }

    IEnumerator DoFreeze()
    {
        isFrozen = true;
        originalTimeScale = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = originalTimeScale;
        //pendingFreezeDuration = 0;
        isFrozen = false;
    }


    private void OnDisable()
    {
        OnPlayerCollFreezeFrame.OnPlayerCollisionEvent -= Freeze;
    }
}
