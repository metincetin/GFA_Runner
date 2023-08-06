using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _forwardSpeed;

	[SerializeField] private float _horizontalSpeed;

	[SerializeField] private Rigidbody _rigidbody;
    
	[SerializeField] private float _jumpPower;
	public float JumpPower
	{
		get => _jumpPower;
		set => _jumpPower = value;
	}

	private Vector3 _velocity = new Vector3();

	public Vector3 Velocity => _rigidbody.velocity;
	
	[SerializeField]
	private float _maxHorizontalDistance;

	private bool _isGrounded;
	public bool IsGrounded => _isGrounded;

	public event Action Jumped;

	private bool _jumpRequested;
	
		
		

	private void Update()
	{
		if (!GameInstance.Instance.IsGameStarted)
		{
			_velocity = Vector3.zero;
			return;
		}

		
		_velocity.z = _forwardSpeed;
		_velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;

		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_jumpRequested)
		{
			_jumpRequested = true;
			Jumped?.Invoke();
			//_rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
			_isGrounded = false;
		}
	}

	private void FixedUpdate()
	{
		if (_jumpRequested)
		{
			_velocity.y = _jumpPower;
			_jumpRequested = false;
		}
		else
		{
			_velocity.y = _rigidbody.velocity.y;
		}

		if (Mathf.Abs(_rigidbody.position.x) > _maxHorizontalDistance)
		{
			var clampedPosition = _rigidbody.position;
			clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_maxHorizontalDistance, _maxHorizontalDistance);

			_rigidbody.position = clampedPosition;
		}
		_rigidbody.velocity = _velocity;

		Debug.DrawRay(_rigidbody.position + Vector3.up, Vector3.down * 1.05f);
		_isGrounded = Physics.Raycast(_rigidbody.position + Vector3.up, Vector3.down, 1.05f);
	}
}