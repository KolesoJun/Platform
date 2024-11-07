using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class SliderChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(CnangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(CnangeVolume);
    }

    private void CnangeVolume(float volue)
    {
        float minVolume = -80f;
        float volumeSound;

        if (volue == 0)
            volumeSound = minVolume;
        else
            volumeSound = Mathf.Log10(volue) * 20;

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, volumeSound);
    }
}
