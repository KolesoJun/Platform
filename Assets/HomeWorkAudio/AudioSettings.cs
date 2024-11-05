using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const string BackgroundVolumeVolume = "Music_Background";
    private const string MasterVolume = "Master";
    private const string ButtonVolume = "UI_Buttons";

    [SerializeField] private AudioMixer _mixer;

    private float _soundOn = 0f;
    private float _soundOff = -80f;

    public void SelectGeneralMode(bool enabled)
    {
        if (enabled)
            _mixer.SetFloat(MasterVolume, _soundOn);
        else
            _mixer.SetFloat(MasterVolume, _soundOff);
    }

    public void CnangeVolumeGeneral(float volue)
    {
        _mixer.SetFloat(MasterVolume, Mathf.Log10(volue) *20);
    }

    public void CnangeVolumeUI(float volue)
    {
        _mixer.SetFloat(ButtonVolume, Mathf.Log10(volue) * 20);
    }

    public void CnangeVolumeBackgroundMusic(float volue)
    {
        _mixer.SetFloat(BackgroundVolumeVolume, Mathf.Log10(volue) * 20);
    }
}
