using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text ambienceValue, masterValue, sfxValue;

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        masterValue.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", MathF.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        sfxValue.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", MathF.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        ambienceValue.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", MathF.Log10(volume) * 20);
    }
}
