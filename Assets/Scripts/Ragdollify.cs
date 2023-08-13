using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdollify : MonoBehaviour
{
    [SerializeField]
    private Collider _characterCollider;

    [SerializeField]
    private Rigidbody _characterRigidbody;

    [SerializeField]
    private Animator _animator;


    private Rigidbody[] _rigidbodies;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void Activate()
    {
        _characterCollider.enabled = false;
        _characterRigidbody.isKinematic = true;
        _animator.enabled = false;

        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = false;
            if (rb.TryGetComponent<Collider>(out var col))
            {
                col.enabled = true;
            }
        }
    }

    public void AddExplosionForce(float force, Vector3 position, float radius)
    {
        foreach(var rb in _rigidbodies)
        {
            rb.AddExplosionForce(force, position, radius, 1, ForceMode.Impulse);
        }
    }
}
