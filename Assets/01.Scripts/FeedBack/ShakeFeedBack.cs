using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeFeedBack : FeedBack
{
    [SerializeField] private Transform _objectToShake;
    [SerializeField] private float _duration = 0.2f, _strength = 1f, _randomness = 90f;
    [SerializeField] private int _vibrato = 10;
    [SerializeField] private bool _snapping = false, _fadeOut = true;

    public override void CompleteFeedback()
    {
        _objectToShake.DOComplete(); // transform에서 진행중인 트윈 모두 종료
    }
    public override void CreateFeedback()
    {
        CompleteFeedback();
        _objectToShake.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
    }
}
