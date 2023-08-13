using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 5f;
    [SerializeField] private float _yOffSet = 5f;

    [SerializeField] private Move _target;
    [SerializeField] private Move _target2;
    [SerializeField] private Move _target3;

    Vector3 _newPosition;

    private Move currentTarget;

    private void Start()
    {
        SetCurrentTarget(_target);
        FixedUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetCurrentTarget(_target);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetCurrentTarget(_target2);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetCurrentTarget(_target3);
        }
    }

    private void SetCurrentTarget(Move target)
    {
        if (currentTarget)
        {
            currentTarget.enabled = false;
            currentTarget.OnDeactivate.Invoke();
        }

        currentTarget = target;

        currentTarget.enabled = true;
        currentTarget.OnActivate.Invoke();
    }

    void FixedUpdate()
    {
        _newPosition = currentTarget.transform.position + new Vector3(0f, 0f, -10f);
        transform.position = Vector3.Lerp(transform.position, _newPosition, _followSpeed * Time.deltaTime);
    }

}
