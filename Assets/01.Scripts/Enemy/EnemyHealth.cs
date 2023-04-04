using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    AIActionData _aiActionData;
    public bool IsEnemy { get; set; }

    public Vector3 _hitPoint { get; private set; }

    protected bool _isDead = false;

    [SerializeField] int _maxHealth;
    protected int _currentHealth;

    public UnityEvent OnGetHit = null;
    public UnityEvent OnDie = null;

    private void Awake()
    {
        _aiActionData = GameObject.Find("AI").GetComponent<AIActionData>();
        _currentHealth = _maxHealth;
    }
    public void GetHit(int damage, GameObject damageDealer, Vector3 hitPoint, Vector3 normal)
    {
        _aiActionData.hitPoint = hitPoint;
        _aiActionData.hitNormal = normal;
        if(_isDead)
        {
            return;
        }

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
}
