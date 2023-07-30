using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFollower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    [SerializeField]
    private float _speed = 8;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
