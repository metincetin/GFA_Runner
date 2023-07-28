using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;


    [SerializeField] private Vector3 _offset;
    

    // Update is called once per frame
    private void LateUpdate()
    {
        var targetPosition = _target.position + _offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
