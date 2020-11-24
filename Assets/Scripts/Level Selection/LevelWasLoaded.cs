using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWasLoaded : MonoBehaviour
{
    public static EventHandler MainLevelWasLoadedEvent;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // 1 == Main Scene
            MainLevelWasLoadedEvent?.Invoke(this, null);
    }
}
