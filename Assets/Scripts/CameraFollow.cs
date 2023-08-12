using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private  Transform _target;
    [SerializeField] private Transform _target2;
    [SerializeField] private Transform _target3;

    Vector3 _newPosition;

    private bool _cat1Active = true;
    private bool _cat2Active, _cat3Active = false;

    private void Start()
    {
        _newPosition = new Vector3(_target.position.x, _target.position.y, -10f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _cat1Active = true;
            _cat2Active = false;
            _cat3Active = false;
        } else if (Input.GetKeyDown(KeyCode.X))
        {
            _cat1Active = false;
            _cat2Active = true;
            _cat3Active = false;
        } else if(Input.GetKeyDown(KeyCode.C))
        {
            _cat1Active = false;
            _cat2Active = false;
            _cat3Active = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowLeader();
        transform.position = Vector3.Slerp(transform.position, _newPosition, _followSpeed * Time.deltaTime);
    }

    void FollowLeader()
    {
        if (_cat1Active)
        {
            _newPosition = new Vector3(_target.position.x, _target.position.y, -10f);
        } else if(_cat2Active)
        {
            _newPosition = new Vector3(_target2.position.x, _target2.position.y, -10f);
        } else if (_cat3Active)
        {
            _newPosition = new Vector3(_target3.position.x, _target3.position.y, -10f);
        }
    }
}
