using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class GGm : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    private Vector2 _destination;
    private Camera _mainCam;
    SpriteRenderer _sr;
    private Tween t = null;
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = new Color(1f, 1f, 1f, 0f);
    }
    private void Start()
    {
        _mainCam = Camera.main;
        _destination = transform.position;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _destination = _mainCam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));


            Sequence seq = DOTween.Sequence();
            seq.Append(_sr.DOFade(1f, 1f));
            seq.Append(transform.DOMove(_destination, 0.7f).SetEase(Ease.InBack));
            seq.Join(transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetLoops(1));
            seq.AppendInterval(1f);
            seq.AppendCallback(() =>
            {
               Debug.Log("¿Ï·á");
            });

        }
    }


    private void MoveToDestination()
    {
        Vector3 dir = (Vector3)_destination - transform.position;
        if(dir.magnitude > 0.1f)
        {
            transform.Translate(dir.normalized * Time.deltaTime * _speed);
        }
    }
}
