using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float _forwardSpeed;

	[SerializeField]
	private float _horizontalSpeed;

	
	private void Start()
	{
	}

	private void Update()
	{
		Vector3 velocity = new Vector3();
		
		velocity.z = _forwardSpeed;
		velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;
		
		transform.position += velocity * Time.deltaTime;
	}
}
