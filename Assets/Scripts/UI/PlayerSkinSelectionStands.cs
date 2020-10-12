using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkinSelectionStands : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> stands;

    private void Start()
    {
        foreach (var item in stands)
        {
            item.SetActive(false);
        }
        PlayerInputManager.instance.onPlayerJoined += ActivateStand;    
    }



    private void ActivateStand(PlayerInput playerInput)
    {
        foreach (var item in stands)
        {
            if(item.activeSelf == false)
            {
                item.SetActive(true);
                return;
            }
        }
    }


    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= ActivateStand;

    }


}
