using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackSolid : FeedBack
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _solidTime = 0.1f;
    
    public override void CompleteFeedback()
    {
        StopAllCoroutines();
        _spriteRenderer.material.SetInt("_isSolidColor", 0);
    }

    public override void CreateFeedback()
    {
        if(_spriteRenderer.material.HasProperty("_isSolidColor"))
        {
            _spriteRenderer.material.SetInt("_isSolidColor", 1);
            StartCoroutine(WaitBeforeChangingBack());
        }
    }

    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(_solidTime);
        _spriteRenderer.material.SetInt("_isSolidColor", 0);
    }
}
