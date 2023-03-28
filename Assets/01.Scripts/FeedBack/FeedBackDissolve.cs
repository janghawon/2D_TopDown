using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FeedBackDissolve : FeedBack
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _duration = 0.1f;

    public UnityEvent FeedbackComplete;
    public override void CompleteFeedback()
    {
        _spriteRenderer.material.SetInt("_isDissolve", 0);
        _spriteRenderer.material.DOComplete();
        _spriteRenderer.material.SetFloat("_Dissolve", 1);
    }

    public override void CreateFeedback()
    {
        _spriteRenderer.material.SetInt("_isDissolve", 1);
        _spriteRenderer.material.DOFloat(0, "_Dissolve", _duration).OnComplete(() =>
        {
            FeedbackComplete?.Invoke();
        });
    }
}
