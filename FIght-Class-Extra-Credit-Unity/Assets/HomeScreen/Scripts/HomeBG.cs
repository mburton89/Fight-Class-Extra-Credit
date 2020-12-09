using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HomeBG : MonoBehaviour
{
    private Vector3 _rotateAmount;

    public float rotationAmount;
    public float duration;

    [SerializeField] private Image leftFace;
    [SerializeField] private Image rightFace;

    [SerializeField] private Sprite[] faces;

    void Start()
    {
        _rotateAmount = new Vector3(0, 0, rotationAmount);
        StartCoroutine(rotateBackAndForth());
        int _r1, _r2;
        _r1 = (int)Random.Range(0, faces.Length);
        _r2 = (int)Random.Range(0, faces.Length);
        while (_r2 == _r1)
        {
            _r2 = (int)Random.Range(0, faces.Length);
            if (faces.Length <= 1) break;
        }
        leftFace.sprite = faces[_r1];
        rightFace.sprite = faces[_r2];
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
