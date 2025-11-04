using UnityEngine;

public class SetJumpFalse : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void EndJumpAnimation()
    {
        Debug.Log("holaa");
        _animator.SetBool("isJumping", false);
        
    }
}
