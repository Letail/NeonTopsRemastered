using System.Collections;
using UnityEngine;

public class RestartTrailOnPlayerLeftArena : MonoBehaviour
{
    private TrailRenderer trail;

    public void TurnTrailEmitingON(object obj, Transform trans)
    {
        StartCoroutine(TurnTrailEmitingONAfterASecond(trans));
    }

    IEnumerator TurnTrailEmitingONAfterASecond(Transform trans)
    {
        yield return new WaitForSeconds(0.5f);
        trail = trans.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab().GetComponent<TrailRenderer>();
        trail.Clear();
        trail.emitting = true;
    }

    public void TurnTrailEmitingOFF(object obj, Transform trans)
    {
        StartCoroutine(TurnTrailEmitingOFFAfterASecond(trans));
    }

    IEnumerator TurnTrailEmitingOFFAfterASecond(Transform trans)
    {
        yield return new WaitForSeconds(1f);
        trail = trans.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab().GetComponent<TrailRenderer>();
        trail.Clear();
        trail.emitting = false;
    }

    private void OnEnable()
    {
        PlayerInOutOfArenaTrigger.PlayerEnteredArenaEvent += TurnTrailEmitingON;
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent += TurnTrailEmitingOFF;
    }
    private void OnDisable()
    {
        PlayerInOutOfArenaTrigger.PlayerEnteredArenaEvent -= TurnTrailEmitingON;
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent -= TurnTrailEmitingOFF;
    }
}
