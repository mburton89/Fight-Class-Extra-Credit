using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HomeBG : MonoBehaviour
{
    private Vector3 _rotateAmount;

    public float rotationAmount;
    public float duration;

    void Start()
    {
        _rotateAmount = new Vector3(0, 0, rotationAmount);
        StartCoroutine(rotateBackAndForth());
    }

    private IEnumerator rotateBackAndForth()
    {
        transform.DORotate(_rotateAmount, duration, RotateMode.Fast).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        transform.DORotate(-_rotateAmount, duration, RotateMode.Fast).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        StartCoroutine(rotateBackAndForth());
    }
}
