using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            var hitNormal = collision.GetContact(0).normal;

            var hitDot = Vector3.Dot(hitNormal, Vector3.forward);

            Debug.Log("HitDot: " + hitDot);
            Debug.DrawRay(collision.GetContact(0).point, hitNormal * 10, Color.red, 10);

            if (hitDot > 0.2f)
            {
                GameInstance.Instance.Lose();
                if (collision.rigidbody.TryGetComponent<PlayerAnimation>(out var animation))
                {
                    animation.OnDied(collision);
                }
                //Destroy(collision.gameObject);
            }
        }
        else
        {
            var normal = collision.GetContact(0).normal;
            collision.rigidbody.AddForce(normal * 30, ForceMode.Impulse);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Debug.Log("CollisionExit: " + collision.rigidbody.name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Debug.Log("CollisionStay: " + collision.rigidbody.name);
        }
    }
}
