using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    private const KeyCode ButtonJump = KeyCode.Space;

    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(AxisHorizontal);

        if (Input.GetKeyDown(ButtonJump))
            _isJump = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
