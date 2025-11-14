using UnityEngine;

[RequireComponent(typeof(PatrolBehavior))]
[RequireComponent(typeof(ChangeSpriteDirectionBehavior))]

public class Enemy : MonoBehaviour
{
    protected PatrolBehavior _pb;
    protected ChangeSpriteDirectionBehavior _csdb;
    private float speed = 2f;
    private Rigidbody2D _rb;
    [SerializeField] private Transform groundCheck;
    private void Awake()
    { 
        _pb = GetComponent<PatrolBehavior>();
        _csdb = GetComponent<ChangeSpriteDirectionBehavior>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = transform.right * speed;
    }

    void Update()
    {
        _pb.Patrol(groundCheck);
        _csdb.ChangeSpriteDirection(_rb.linearVelocityX);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
