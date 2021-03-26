using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 _direction;
    [SerializeField]
    private float _speed = 10;
    [SerializeField]
    private float _jumpForce = 10;
    private bool _isGrounded = false;
    [SerializeField]
    private Transform _isGroundedChecker;
    [SerializeField]
    private float _checkGroundRadius = 5;
    [SerializeField]
    private LayerMask _groundLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
        CheckIfGrounded();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * _speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
        }
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_isGroundedChecker.position, _checkGroundRadius, _groundLayer);
        if (collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
