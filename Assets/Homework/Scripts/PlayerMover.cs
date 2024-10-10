using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        transform.Translate(transform.right * direction * _speed * Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        float angleLeft = 180f;

        if (direction >= 0f)
            transform.rotation = new Quaternion();
        else
            transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _force);
    }
}
