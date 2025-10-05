using NUnit.Framework.Constraints;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 300f;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator _animator;

    private float _moveDirection;
    private float _groundRadius = 0.3f;
    private bool _isFacingRight = true;
    private bool _isJumping;
    private bool _isGrounded;

    void Awake()
    {
        InputManager.instance.jumpEvent.AddListener(Jump); //Add the jump function to the jump input event
    }

    private void OnDestroy()
    {
        InputManager.instance.jumpEvent.RemoveListener(Jump); //Remove listener when the scene ends
    }

    private void Update()
    {
        GetInput();
        UpdateAnimation();
        PlayerRun();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
        ApplyMovement();
    }

    private void GetInput()
    {
        _moveDirection = Input.GetAxis("Horizontal");
    }

    private void UpdateAnimation()
    {
        // Flip sprite
        if (_moveDirection != 0)
        {
            _isFacingRight = _moveDirection > 0;
            _renderer.flipX = !_isFacingRight;
        }
    }

    private void ApplyMovement()
    {
        _rb.linearVelocity = new Vector2(_moveDirection * _moveSpeed, _rb.linearVelocity.y);
        if (_isJumping && _isGrounded)
        {
            _rb.AddForce(new Vector2(0f, _jumpHeight));
        }
        _isJumping = false;
    }

    private void Jump()
    {
        _isJumping = true;
    }

    private void PlayerRun()
    {
        if (_rb.linearVelocityX != 0.0f && _isGrounded)
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    private void PlayerJump()
    {
        if (_isGrounded == false)
        {
            _animator.SetBool("isGrounded", _isGrounded);
        }
        else
        {
            _animator.SetBool("isGrounded", _isGrounded);
        }
    }
}
