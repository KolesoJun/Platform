using UnityEngine;
using UnityEngine.UI;

public class ButtonHealthEffects : MonoBehaviour
{
    [SerializeField] private float _countDamage;
    [SerializeField] private float _amountTreatment;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonMedical;

    private void OnEnable()
    {
        _buttonDamage.onClick.AddListener(Damage);
        _buttonMedical.onClick.AddListener(Treat);
    }

    private void OnDisable()
    {
        _buttonDamage.onClick.RemoveListener(Damage);
        _buttonMedical.onClick.RemoveListener(Treat);
    }

    private void Damage()
    {
        _health.TakeDamage(_countDamage);
    }

    private void Treat()
    {
        _health.ReplenishHealth(_amountTreatment);
    }
}
