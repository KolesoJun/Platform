using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SoundOperationSwitch : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    private Toggle _toggle;
    private float _soundOn = 0f;
    private float _soundOff = -80f;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SelectGeneralMode);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SelectGeneralMode);
    }

    public void SelectGeneralMode(bool enabled)
    {
        if (enabled)
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, _soundOn);
        else
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, _soundOff);
    }
}
