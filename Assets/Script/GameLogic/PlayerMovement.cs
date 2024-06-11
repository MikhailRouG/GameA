using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedForward;
    [SerializeField] private float _speedRight;
    [SerializeField] private float _sprintSpeed;
    private Rigidbody _rigidbody;
    private Animator _animator;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector3 velocity, bool sprint)
    {
        Vector3 direction = transform.right * velocity.x * _speedRight + transform.forward * velocity.z * _speedForward;
        if (sprint) _rigidbody.velocity = direction * _sprintSpeed * Time.deltaTime;
        else _rigidbody.velocity = direction * Time.deltaTime;
    }
}
