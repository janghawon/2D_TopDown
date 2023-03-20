using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : poolableMono
{
    public bool IsEnemy;
    public int DamageFsctor = 1;
    [SerializeField] private float _TTL;
    [SerializeField] private float _timeToLive;
    [SerializeField] float _bulletSpeed;
    private Rigidbody2D _rigid;
    bool isDead;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _timeToLive += Time.fixedDeltaTime;
        _rigid.MovePosition(transform.position + transform.right * _bulletSpeed * Time.fixedDeltaTime);

        if(_timeToLive >= _TTL)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }
    }
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }

    public override void Reset()
    {
        isDead = false;
        _timeToLive = 0;
    }
}
