using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpTrajectoryInstantiator : MonoBehaviour
{
    [SerializeField]
    private float _magnitude = 1;

    [SerializeField]
    private float _distance = 3;
    
    [SerializeField]
    private int _instanceCount;
    
    [SerializeField]
    private GameObject _objectToInstantiate;
    
    [SerializeField]
    private AnimationCurve _curve;
    
    [SerializeField]
    private bool _useAnimationCurve;

    private void Start()
    {
        CreateObjects();
    }


    private void OnDrawGizmos()
    {
        //Gizmos.
        for (int i = 0; i < _instanceCount - 1; i++)
        {
            Vector3 startPosition = new Vector3();
            Vector3 endPosition = new Vector3();

            // _distance / 2 == _distance * 0.5f;
            float startTime = (float)i / (_instanceCount - 1);
            float endTime = (float)(i + 1) / (_instanceCount - 1);
            
            startPosition.z = Mathf.Lerp(-_distance * 0.5f, _distance * 0.5f, startTime);
            endPosition.z = Mathf.Lerp(-_distance * 0.5f, _distance * 0.5f, endTime);
            
            if (_useAnimationCurve)
            {
                startPosition.y = _curve.Evaluate(startTime) * _magnitude;
                endPosition.y = _curve.Evaluate(endTime) * _magnitude;
            }
            else
            {
                startPosition.y = Mathf.Sin(startTime* Mathf.PI) * _magnitude;
                endPosition.y = Mathf.Sin(endTime * Mathf.PI) * _magnitude;
            }

            Gizmos.DrawLine(transform.position + startPosition, transform.position + endPosition);
        }
    }

    private void CreateObjects()
    {
        foreach (Transform c in transform)
        {
            Destroy(c.gameObject);
        }

        for (int i = 0; i < _instanceCount; i++)
        {
            var objectInstance = Instantiate(_objectToInstantiate, transform);
            Vector3 localPosition = new Vector3();
            
            // 0 ----0.5---0.9 1 
            // 10 ---15----18 20

            // _distance / 2 == _distance * 0.5f;
            float time = (float)i / (_instanceCount - 1);
            
            localPosition.z = Mathf.Lerp(-_distance * 0.5f, _distance * 0.5f, time);
            
            if (_useAnimationCurve)
            {
                localPosition.y = _curve.Evaluate(time) * _magnitude;
            }
            else
            {
                localPosition.y = Mathf.Sin(time * Mathf.PI) * _magnitude;
            }

            objectInstance.transform.localPosition = localPosition;
        }
    }
}
