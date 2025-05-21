using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMovement(InputValue input)
    {
        if (audioSource.clip != SoundBank.Instance.stepAudio)
        {
            audioSource.clip = SoundBank.Instance.stepAudio;
            audioSource.loop = true;
        }
        if (!audioSource.isPlaying) audioSource.Play();
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
    }
}
