using UnityEngine;

public class ChangeGravityBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeGravity( ref bool gravityFlipped)
    { 
        gravityFlipped = !gravityFlipped;

        Physics2D.gravity = new Vector2(0, gravityFlipped ? 9.81f : -9.81f);

        transform.Rotate(0f, 0f, 180f);

        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, -_rb.linearVelocityY);
    }
}
