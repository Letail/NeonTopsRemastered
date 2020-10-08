using UnityEngine;

public class OnTabSelectedBehaviour : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        TabButton.OnTabDeselectedEvent += PlaySound;
    }

    void PlaySound(GameObject gameObject)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
