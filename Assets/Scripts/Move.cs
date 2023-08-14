using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;
    public UnityEvent OnJump;
    
    private Rigidbody2D rb2d;

    [Header("Movimiento")]

    private float _moveHorizontal;
    [SerializeField] private float _speed = 1000f;
    [Range(0, 0.3f)][SerializeField] private float _smoother;

    Vector3 _moveVelocity = Vector3.zero;

    private bool _isRight = false;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 1000f;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private Transform _floorController;
    [SerializeField] private Vector3 _boxDimensions;
    [SerializeField] private bool _isFloor;
    bool _jump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * _speed;

        if(Input.GetButtonDown("Jump"))
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

        if ((mover > 0 && !_isRight) || (mover < 0 && _isRight))
        {
            Spin();
        }

        if (_isFloor && saltar)
        {
            _isFloor = false;
            rb2d.AddForce(new Vector2(0f, _jumpForce));
            OnJump.Invoke();
        }
    }

    private void Spin()
    {
        _isRight = !_isRight;
        Vector3 _scale = transform.localScale;
        _scale.x *= -1;
        transform.localScale = _scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorController.position, _boxDimensions);
    }
}
