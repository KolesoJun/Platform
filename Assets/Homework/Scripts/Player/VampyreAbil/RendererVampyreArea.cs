using UnityEngine;
using UnityEngine.UI;

public class RendererVampyreArea : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _imageArea;
    [SerializeField] private TimerVampyre _timerVampyre;
    [SerializeField] private TargetHandler _targetHandler;

    private void Awake()
    {
        Off();
    }

    private void OnEnable()
    {
        _timerVampyre.Activated += On;
        _timerVampyre.Deactivated += Off;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        _timerVampyre.Activated -= On;
        _timerVampyre.Deactivated -= Off;
    }

    private void On()
    {
        _imageArea.enabled = true;
    }

    private void Off()
    {
        _imageArea.enabled = false;
    }
}
