﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddExistingPlayersToCameraTargets : MonoBehaviour
{
    [SerializeField]
    private PlayersInGame playersInGameSO; //The list of the existing players
    private CameraMultiTarget cameraMultiTarget;
    private GameObject visualsPrefab;
    private List<GameObject> targets;


    void Start()
    {
        cameraMultiTarget = GetComponent<CameraMultiTarget>();
        targets = new List<GameObject>();

        if (playersInGameSO.playerSphereTransforms != null)
        {
            GameObject[] alreadyExistingTargets = cameraMultiTarget.GetTargets();
            if (alreadyExistingTargets.Length != 0)
            {
                foreach (Transform sphereTrans in playersInGameSO.playerSphereTransforms)
                {
                    if (sphereTrans == null) continue;

                    visualsPrefab = sphereTrans.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab();

                    //Checking if the visualsPrefab is in the array
                    if (Array.Exists(alreadyExistingTargets, x => x == visualsPrefab))
                    {
                        targets.Add(visualsPrefab);
                    }
                }
                cameraMultiTarget.SetTargets(targets.ToArray());
            }
            else
            {
                //If the camera doesn't have any targets yet, we don't need to check for duplicates,
                //and can directly pass all the targets
                foreach (Transform sphereTrans in playersInGameSO.playerSphereTransforms)
                {
                    if (sphereTrans == null) continue;

                    visualsPrefab = sphereTrans.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab();
                    targets.Add(visualsPrefab);
                }
                cameraMultiTarget.SetTargets(targets.ToArray());
            }
        }
    }
}
