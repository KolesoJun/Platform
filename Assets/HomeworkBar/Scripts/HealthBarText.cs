using UnityEngine;
using TMPro;

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private TMP_Text _textUI;

    private void OnEnable()
    {
        _health.ChangedCurrentHealth += View;
        _health.Teated += View;
    }

    private void OnDisable()
    {
        _health.ChangedCurrentHealth -= View;
        _health.Teated -= View;
    }

    private void View(float health)
    {
        char splash = '/';
        _textUI.text = health.ToString() + splash + _health.HealthMax.ToString();
    }
}
