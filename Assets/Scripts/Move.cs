using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /*
    private Rigidbody2D rb2d;

    [Header("Movimiento")]

    private float _moveHorizontal;
    [SerializeField] private float _speed;
    [Range(0, 0.3f)][SerializeField] private float _smoother;

    Vector3 _moveVelocity = Vector3.zero;

    private bool _isRight = false;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private Transform _floorController;
    [SerializeField] private Vector3 _boxDimensions;
    [SerializeField] private bool _isFloor;
    private bool _jump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * _speed;

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }
    }

    private void FixedUpdate()
    {
        _isFloor = Physics2D.OverlapBox(_floorController.position, _boxDimensions, 0f, _floor);

        Motion(_moveHorizontal * Time.fixedDeltaTime, _jump);

        _jump = false;
    }

    private void Motion(float mover, bool saltar)
    {
        Vector3 _speedObject = new Vector2(mover, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, _speedObject, ref _moveVelocity, _smoother);

        if((mover > 0 && !_isRight) || (mover < 0 && _isRight))
        {
            Spin();
        } 

        if(_isFloor && saltar)
        {
            _isFloor = false;
            rb2d.AddForce(new Vector2(0f, _jumpForce));
        }
    }

    private void Spin()
    {
        _isRight = !_isRight;
        Vector3 _scale = transform.localScale;
        _scale.x *= -1;
        transform.localScale = _scale;
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorController.position, _boxDimensions);
    }
    */

    [SerializeField] private CharacterController2D _controller;

    float _horizontalMove = 0f;

    private bool _jump = false;

    [SerializeField] float _runSpeed = 100f;

    private void Start()
    {
        
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed ;

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }
    }

    private void FixedUpdate() 
    {
        _controller.Motion(_horizontalMove * Time.fixedDeltaTime, false, _jump);
        _jump = false;
    }
}
