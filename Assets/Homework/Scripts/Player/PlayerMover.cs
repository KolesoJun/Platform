using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Player _player;
    
    [field: SerializeField] public float Force { get; private set; }

    public void Move(float direction)
    {
        _player.transform.Translate(_player.transform.right * direction * _speed * Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        float angleLeft = 180f;

        if (direction >= 0f)
            _player.transform.rotation = new Quaternion();
        else
            _player.transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * Force);
    }
}
