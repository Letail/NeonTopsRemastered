using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class SetPlayerColor : MonoBehaviour
{
    private List<Material> skins;
    private List<Material> skinsInUse;

    [Header("Player Colors")]
    public Material skinPlayer1;
    public Material skinPlayer2;
    public Material skinPlayer3;
    public Material skinPlayer4;

    private void Awake()
    {
        skins = new List<Material>
        {
            skinPlayer1,
            skinPlayer2,
            skinPlayer3,
            skinPlayer4
        };

        skinsInUse = new List<Material>();
    }

    int GetUnusedSkin()
    {
        if (skinsInUse.Count == 0)
        {
            skinsInUse.Add(skins[0]);
            return 0;
        }
        else
        {
            for (int i = 0; i < skins.Count; i++)
            {
                for (int ii = 0; ii < skinsInUse.Count; ii++)
                {
                    if (skins[i] != skinsInUse[ii])
                    {
                        skinsInUse.Add(skins[i]);
                        return i;
                    }
                }
            }
        }        
        return 0;
    }

    void RemoveColorFromUsedList(Material skin)
    {
        if (skinsInUse.Contains(skin))
        {
            skinsInUse.Remove(skin);
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {

        playerInput.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab()
            .GetComponent<PlayerSkin>().SkinMaterial = skins[GetUnusedSkin()];
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        if (PlayerInputManager.instance != null)
        {
            RemoveColorFromUsedList(playerInput.gameObject.GetComponent<SpawnCharacterVisualsPrefab>().GetPrefab()
            .GetComponent<PlayerSkin>().SkinMaterial);
        }        
    }

    private void OnEnable()
    {
        //PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        //PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance != null)
        {
            //PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            //PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
        }
    }
}
