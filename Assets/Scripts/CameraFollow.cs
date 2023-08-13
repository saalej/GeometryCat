using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 5f;
    [SerializeField] private float _yOffSet = 5f;

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _target2;
    [SerializeField] private Transform _target3;

    bool t1 = true; 
    bool t2, t3 = false;

    Vector3 _newPosition;

    private void Start()
    {
        _newPosition = new Vector3(_target.position.x, _target.position.y + _yOffSet, -10f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
        {
            FollowLeader();
        }
    }

    void FixedUpdate()
    {
        if (t1)
        {
            _newPosition = _target.position + new Vector3(0f, 0f, -10f);
        }
        else if (t2)
        {
            _newPosition = _target2.position + new Vector3(0f, 0f, -10f);
        }
        else if (t3)
        {
            _newPosition = _target3.position + new Vector3(0f, 0f, -10f);
        }
        transform.position = Vector3.Lerp(transform.position, _newPosition, _followSpeed * Time.deltaTime);
    }

    void FollowLeader()
    {
        t1 = Input.GetKeyDown(KeyCode.Z);
        t2 = Input.GetKeyDown(KeyCode.X);
        t3 = Input.GetKeyDown(KeyCode.C);
    }
}
