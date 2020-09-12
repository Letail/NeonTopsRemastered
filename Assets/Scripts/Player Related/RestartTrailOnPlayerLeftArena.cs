using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrailOnPlayerLeftArena : MonoBehaviour
{
    private TrailRenderer trail;

    public void TurnTrailEmitingON(Transform trans)
    {
        StartCoroutine(TurnTrailEmitingONAfterASecond(trans));
    }

    IEnumerator TurnTrailEmitingONAfterASecond(Transform trans)
    {
        yield return new WaitForSeconds(0.5f);
        trail = trans.gameObject.GetComponent<SpawnPlayersVisualsPrefab>().GetPrefab().GetComponent<TrailRenderer>();
        trail.Clear();
        trail.emitting = true;
    }

    public void TurnTrailEmitingOFF(Transform trans)
    {
        StartCoroutine(TurnTrailEmitingOFFAfterASecond(trans));
    }

    IEnumerator TurnTrailEmitingOFFAfterASecond(Transform trans)
    {
        yield return new WaitForSeconds(1f);
        trail = trans.gameObject.GetComponent<SpawnPlayersVisualsPrefab>().GetPrefab().GetComponent<TrailRenderer>();
        trail.Clear();
        trail.emitting = false;
    }

    private void OnEnable()
    {
        PlayerInOutOfArenaTrigger.OnPlayerInArenaEvent += TurnTrailEmitingON;
        PlayerInOutOfArenaTrigger.OnPlayerOutOfArenaEvent += TurnTrailEmitingOFF;
    }
    private void OnDisable()
    {
        PlayerInOutOfArenaTrigger.OnPlayerInArenaEvent -= TurnTrailEmitingON;
        PlayerInOutOfArenaTrigger.OnPlayerOutOfArenaEvent -= TurnTrailEmitingOFF;
    }
}
