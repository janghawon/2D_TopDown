using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public bool IsEnemy { get; set; }
    public Vector3 _hitPoint { get; private set; }

    protected bool _isDead = false; //사망 여부를 나타내는 것

    [SerializeField]
    protected int _maxHealth; //이건 나중에 SO로 빼게될 거다.

    protected int _currentHealth;

    public UnityEvent OnGetHit = null;  //맞았을 때 발생할 이벤트랑
    public UnityEvent OnDie = null;  // 죽었을 때 발생할 이벤트

    private AIActionData _aiActionData;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
    }

    public void GetHit(int damage, GameObject damageDealer, Vector3 hitPoint, Vector3 normal)
    {
        if (_isDead) return;

        _aiActionData.hitPoint = hitPoint;
        _aiActionData.hitNormal = normal;

        _currentHealth -= damage;

        OnGetHit?.Invoke();

        if(_currentHealth <= 0)
        {
            DeadProcess();
        }
    }

    private void DeadProcess()
    {
        _isDead = true;
        OnDie?.Invoke();
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
    }
}
