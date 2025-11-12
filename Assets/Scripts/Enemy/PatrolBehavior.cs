using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 3f;
    private int _direction = 1;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void EnemyPatrol(float _enemyLimitPositionXPositive, float _enemyLimitPositionXNegative)
    {
        if (transform.position.x >= _enemyLimitPositionXPositive)
        {
            _direction = -1;
        }
        else if (transform.position.x <= _enemyLimitPositionXNegative)
        {
            _direction = 1;
        }

        _rb.linearVelocity = new Vector2(_direction * speed, _rb.linearVelocityY);
    }
}
