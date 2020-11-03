using System;
using System.Collections;
using UnityEngine;

public class BringPlayerBackToArena : MonoBehaviour
{
    [SerializeField]
    private float delay;

    public Vector3 arenaBringBackPosition;


    public void BringBack(object sender, Transform trans)
    {
        StartCoroutine(BringBackAfterDelay(trans, delay));

    }

    IEnumerator BringBackAfterDelay(Transform trans, float timeDelay)
    {
        Rigidbody rb = trans.gameObject.GetComponent<Rigidbody>();

#if UNITY_EDITOR
        //If before setting the rb to kinematic its collision detection isn't set to "ContinuousSpeculative",
        //then Unity will throw a warning and clog the console, so we're just avoiding this here.
        CollisionDetectionMode previousMode = rb.collisionDetectionMode;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
#endif

        rb.isKinematic = true;

        yield return new WaitForSeconds(timeDelay);
        //OnPlayerBackOnArenaEvent?.Invoke(trans);


        rb.isKinematic = false;

#if UNITY_EDITOR
        rb.collisionDetectionMode = previousMode;
#endif

        trans.position = arenaBringBackPosition;

        //Calling ForgetPreviousTransforms() so we can "teleport" the player back
        //without having interpolation

        trans.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab().GetComponent<InterpolatedTransform>().ForgetPreviousTransforms();
    }


    private void OnEnable()
    {
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent += BringBack;
    }
    private void OnDisable()
    {
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent -= BringBack;
    }
}
