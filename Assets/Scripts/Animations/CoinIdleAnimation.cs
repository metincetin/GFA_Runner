using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinIdleAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.DOLocalMoveY(1, 1).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalRotate(Vector3.up * 360,2, RotateMode.WorldAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
