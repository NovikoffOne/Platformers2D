using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _groundDetect;

    private bool _moveLeft = true;
    private float _rayLength = 1f;
    private Vector3 _direction;

    private void Start()
    {
        _direction = transform.right;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerEnity player = collision.gameObject.GetComponent<PlayerEnity>();

        if (player)
        {
            player.TakeDamage();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);

        RaycastHit2D groundCheck = Physics2D.Raycast(_groundDetect.position, Vector2.down, _rayLength);

        if(groundCheck.collider == false)
        {
            _direction *= -1f;

            if(_moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);

                _moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                _moveLeft = true;
            }
        }
    }
}
