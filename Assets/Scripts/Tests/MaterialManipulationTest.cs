using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManipulation : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        _renderer.material.SetFloat("_Random", Random.value);
    }
}
