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

    private List<GameObject> _instanceList = new List<GameObject>();
    
    private void OnValidate()
    {
        CreateObjects();
    }

    private void Start()
    {
        CreateObjects();
    }

    #if UNITY_EDITOR
    // it seems, for Destroy calls to be working inside OnValidate event, we have to call a coroutine.
    private IEnumerator RemoveDelayed(GameObject obj)
    {
        yield return null;
        DestroyImmediate(obj);
    }
    #endif
    
    private void CreateObjects()
    {
        foreach (Transform c in transform)
        {
            #if UNITY_EDITOR
            StartCoroutine(RemoveDelayed(c.gameObject));
            #else
            Destroy(c.gameObject);
            #endif
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
        
        #if UNITY_EDITOR
        // Setting dirty means there is a change. Without dirty flag, unity considers there is no change, so it might not be saved at all.
        EditorUtility.SetDirty(gameObject);
        #endif
    }
}
