using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionFinish : MonoBehaviour
{
    public delegate void FinishSelection();
    public static event FinishSelection FinishSelectionEvent;

    [Header("Scenes Indexes")]
    [SerializeField] private int multiplayerSceneIndex;

    private void Start()
    {
        FinishSelectionEvent += LoadMultiplayerScene;
    }

    public void LoadMultiplayerScene()
    {
        SceneManager.LoadSceneAsync(multiplayerSceneIndex);
    }
}
