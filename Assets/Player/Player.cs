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
    protected Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _csdb = GetComponent<ChangeSpriteDirectionBehavior>();
        _mb = GetComponent<MoveBehavior>();
        _cg = GetComponent<ChangeGravityBehavior>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        _mb.MoveCharacterHorizontal(new Vector2(Input.GetAxis("Horizontal"), 0), speed);
        _animator.SetFloat("Velocity", Mathf.Abs(_rb.linearVelocityX));
        _csdb.ChangeSpriteDirectionWithChangeGravity(_rb.linearVelocityX, gravityFlipped);
        if(_cg.IsGrounded())
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                _animator.SetTrigger("Jump");
                _cg.ChangeGravity(ref gravityFlipped);
            }
            Debug.Log("SALTOOOOO");
            _animator.SetBool("Grounded", true);
        } 
        else
            _animator.SetBool("Grounded", false);

    }
}
