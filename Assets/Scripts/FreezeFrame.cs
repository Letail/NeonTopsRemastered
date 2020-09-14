using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float freezeDuration;
    private float pendingFreezeDuration = 0;
    private bool isFrozen;
    private float originalTimeScale;

    //private void Update()
    //{
    //    if(isFrozen ==  false && pendingFreezeDuration != 0)
    //    {
    //        StartCoroutine(DoFreeze);
    //    }
    //}
    private void Awake()
    {
        isFrozen = false;
        OnPlayerCollFreezeFrame.OnPlayerCollEvent += Freeze;
    }
    public void Freeze()
    {
        if(isFrozen == false) StartCoroutine(DoFreeze());
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
        OnPlayerCollFreezeFrame.OnPlayerCollEvent -= Freeze;
    }
}
