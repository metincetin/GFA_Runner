using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.attachedRigidbody.CompareTag("Player"))
		{
			OnCollected();
			Destroy(gameObject);
		}
	}

	protected abstract void OnCollected();
}
