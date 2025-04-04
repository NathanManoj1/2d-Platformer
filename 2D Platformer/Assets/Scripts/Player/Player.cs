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
    [SerializeField]
    private AudioSource _jump;
    private Animator _anim;
    [SerializeField]
    private AudioSource _walkingGrass;
    Vector3 characterScale;
    float characterScaleX;
    UIManager _uimanager;
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
            Debug.LogError("Animator is NULL");
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Rigidbody2D is NULL");
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
    }
    private void Update()
    {

        Jump();
        CheckIfGrounded();
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
            _anim.SetBool("IsRunning", false);
            _walkingGrass.Pause();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetBool("IsRunning", true);
            _walkingGrass.Play();
        }
        if (_isGrounded == true)
            _anim.SetBool("IsGrounded", true);
        if (_isGrounded == false)
        _anim.SetBool("IsGrounded", false);

    }
    private void FixedUpdate()
    {
        if (_uimanager._paused == false) {
            Move();

        }

    }
    private void Move()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * _speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        // Flip the Character:
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;
    }
    private void Jump()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _anim.SetTrigger("Jump");
            _jump.Play();
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
