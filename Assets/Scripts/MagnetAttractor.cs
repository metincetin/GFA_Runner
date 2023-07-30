using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttractor : MonoBehaviour
{
    public float Radius { get; set; } = 10;
    // Update is called once per frame
    private void FixedUpdate()
    {
        var collidersInRange = Physics.OverlapSphere(transform.position, Radius, LayerMask.GetMask("Default"), QueryTriggerInteraction.Collide);
        
        foreach (var collider in collidersInRange)
        {
            if (!collider.isTrigger) continue;
            if (collider.TryGetComponent<Gold>(out var _))
            {
                var follower = collider.gameObject.AddComponent<MagnetFollower>();
                follower.Target = transform;
            }
        }
    }
}
