using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _forwardSpeed;

	[SerializeField] private float _horizontalSpeed;

	[SerializeField] private Rigidbody _rigidbody;
	
    private Vector3 _velocity = new Vector3();

	private void Start()
	{
	}

	private void Update()
	{
		_velocity.z = _forwardSpeed;
		_velocity.y = _rigidbody.velocity.y;
		_velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;
	}

	private void FixedUpdate()
	{
		_rigidbody.velocity = _velocity;
	}
}