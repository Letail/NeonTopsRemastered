using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionFinish : MonoBehaviour
{
    public static event EventHandler FinishSelectionEvent;

    [Header("Scenes Indexes")]
    [SerializeField] private int multiplayerSceneIndex;

    private void Start()
    {
        FinishSelectionEvent += LoadMultiplayerScene;
    }

    public void LoadMultiplayerScene(object sender, EventArgs e)
    {
        SceneManager.LoadSceneAsync(multiplayerSceneIndex);
    }
}
