using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveBehavior))]
[RequireComponent(typeof(ChangeSpriteDirectionBehavior))]
[RequireComponent(typeof(ChangeGravityBehavior))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions, IDammageable
{
    protected ChangeSpriteDirectionBehavior _csdb;
    private Rigidbody2D _rb;
    protected ChangeGravityBehavior _cg;
    protected MoveBehavior _mb;
    protected float speed = 5;
    private bool gravityFlipped = false;
    protected Animator _animator;
    
    private float horizontalVelocity;
    private InputSystem_Actions _actions;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _csdb = GetComponent<ChangeSpriteDirectionBehavior>();
        _mb = GetComponent<MoveBehavior>();
        _cg = GetComponent<ChangeGravityBehavior>();
        _rb = GetComponent<Rigidbody2D>();
        _actions =  new InputSystem_Actions();
        _actions.Player.SetCallbacks(this);
    }

    public void Update()
    {
        _mb.MoveCharacterHorizontal(new Vector2(horizontalVelocity, 0), speed);
        _animator.SetFloat("Velocity", Mathf.Abs(_rb.linearVelocityX));
        _csdb.ChangeSpriteDirectionWithChangeGravity(_rb.linearVelocityX, gravityFlipped);
        _animator.SetBool("Grounded", true);
        if (_cg.IsGrounded())
        {
            _animator.SetBool("Grounded", true);
        }
        else
            _animator.SetBool("Grounded", false);
    } 
    private void ControlInputs(bool enable)
    {
        if (enable) 
            _actions.Disable();
        else _actions.Enable();
    }
    public void Die()
    {
        _animator.SetTrigger("Death");
        _actions.Disable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalVelocity = context.ReadValue<Vector2>().x;
        if (_cg.IsGrounded())
        {
            if (context.ReadValue<Vector2>().y!=0)
            {
                _animator.SetTrigger("Jump");
                _cg.ChangeGravity(ref gravityFlipped);
            }
            _animator.SetBool("Grounded", true);
        }
        else
            _animator.SetBool("Grounded", false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
    public void OnEnable()
    {
        _actions.Enable();
        Dialogue.PausePlayer += ControlInputs;
    }
    public void OnDisable()
    {
        Dialogue.PausePlayer -= ControlInputs;
        _actions.Disable();
    }
}
