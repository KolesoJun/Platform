using UnityEngine;
using TMPro;

public class HealthViewText : MonoBehaviour
{
    [SerializeField] private TMP_Text _textUI;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ChangedCountCurrent += View;
    }

    private void OnDisable()
    {
        _health.ChangedCountCurrent -= View;
    }

    private void View(float health)
    {
        char splash = '/';
        _textUI.text = health.ToString() + splash + _health.CountMax.ToString();
    }
}
