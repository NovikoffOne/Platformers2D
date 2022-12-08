using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private LayerMask _ground;

    private SpriteRenderer _sprite;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Transform _groundCheck;
    private bool _isGround;
    private float _checkRadius = 0.3f;

    private enum States
    {
        Idel,
        Run,
        Jump
    }

    private States _state
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _animator = GetComponent<Animator>();

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _groundCheck = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        if(_isGround == true)
        {
            _state = States.Idel;
        }

        if(Input.GetButton("Horizontal") == true)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && _isGround == true)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Move()
    {
        if(_isGround == true)
        {
            _state = States.Run;
        }

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        _sprite.flipX = direction.x < 0.0f;

        float speed = Mathf.Abs(direction.x);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }

    private void CheckGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        
        if(_isGround == false)
        {
            _state = States.Jump;
        }
    }
}
