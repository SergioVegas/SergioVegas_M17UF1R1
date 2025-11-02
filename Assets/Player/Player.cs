using UnityEngine;

[RequireComponent(typeof(MoveBehavior))]
[RequireComponent(typeof(ChangeSpriteDirectionBehavior))]
[RequireComponent(typeof(ChangeGravityBehavior))]
public class Player : MonoBehaviour
{
    protected ChangeSpriteDirectionBehavior _csdb;
    private Rigidbody2D _rb;
    protected ChangeGravityBehavior _cg;
    protected MoveBehavior _mb;
    protected float speed = 5;
    private bool gravityFlipped = false;
    [SerializeField] protected Animator _animator;
    private void Awake()
    {
        _csdb = GetComponent<ChangeSpriteDirectionBehavior>();
        _mb = GetComponent<MoveBehavior>();
        _cg = GetComponent<ChangeGravityBehavior>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        _mb.MoveCharacterHorizontal(new Vector2(Input.GetAxis("Horizontal"), 0), speed);
        _animator.SetFloat("Velocity", _rb.linearVelocityX);
        _csdb.ChangeSpriteDirectionWithChangeGravity(_rb.linearVelocityX, gravityFlipped);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _cg.ChangeGravity(ref gravityFlipped);
        }
    }
}
