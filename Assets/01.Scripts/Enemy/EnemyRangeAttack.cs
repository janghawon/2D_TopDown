using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRangeAttack : EnemyAttack
{
    [SerializeField] private GameObject _fireBall;
        

    [SerializeField] private float _coolTime = 3f;
    private float _lastFireTime = 0;

    public override void Attack()
    {
        if(_actionData.IsAttack == false && _lastFireTime + _coolTime > Time.time)
        {
            _actionData.IsAttack = true;

            StartAttackSequence();
        }
    }

    private void StartAttackSequence()
    {
        Sequence seq = DOTween.Sequence();

        FireBall fb = PoolManager.Instance.Pop("FireBall") as FireBall;

        fb.transform.position = transform.position + new Vector3(0, 0.25f, 0);
        fb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        seq.Append(fb.transform.DOMoveY(fb.transform.position.y + 0.5f, 0.5f));
        seq.Join(fb.transform.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 0.5f));
    }
}
