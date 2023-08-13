using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private PlayerMovement _movement;
    
    [SerializeField]
    private Ragdollify _ragdollify;

    private void OnEnable()
    {
        _movement.Jumped += OnJumped;
    }

    private void OnDisable()
    {
        _movement.Jumped -= OnJumped;
    }

    private void OnJumped()
    {
        _animator.SetTrigger("Jump");
    }

    private void Update()
    {
        _animator.SetFloat("MovementSpeed", _movement.Velocity.z);
        _animator.SetBool("IsGrounded", _movement.IsGrounded);
    }

    public void OnDied(Collision collision)
    {
        _ragdollify.Activate();
        _ragdollify.AddExplosionForce(15, collision.GetContact(0).point, 5);
    }
}
