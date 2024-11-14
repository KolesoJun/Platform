using System;
using UnityEngine;
using UnityEngine.UI;

public class InputReader : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    private const KeyCode ButtonJump = KeyCode.Space;

    [SerializeField] private Button _buttonVampirism;

    public float Direction { get; private set; }

    public event Action Jumped;
    public event Action ActivatedVampirism;

    private void OnEnable()
    {
        _buttonVampirism.onClick.AddListener(ClickVampirism);
    }

    private void Update()
    {
        Direction = Input.GetAxis(AxisHorizontal);

        if (Input.GetKeyDown(ButtonJump))
            Jumped?.Invoke();
    }

    private void OnDisable()
    {
        _buttonVampirism.onClick.RemoveListener(ClickVampirism);
    }

    private void ClickVampirism()
    {
        ActivatedVampirism.Invoke();
    }
}
