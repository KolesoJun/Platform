using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _button.onClick.AddListener(_audio.Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_audio.Play);
    }
}
