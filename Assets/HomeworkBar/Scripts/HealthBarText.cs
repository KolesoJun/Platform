using UnityEngine;
using TMPro;

public class HealthBarText : HealthBar
{
    [SerializeField] private TMP_Text _textUI;

    protected override void View(float health)
    {
        char splash = '/';
        _textUI.text = health.ToString() + splash + Health.HealthMax.ToString();
    }
}
