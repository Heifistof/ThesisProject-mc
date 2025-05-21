using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public AudioClip stepAudio;
    public static SoundBank Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
