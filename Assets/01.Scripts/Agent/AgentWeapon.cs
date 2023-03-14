using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float _desireAngle; //무기가 바라봐야 하는 방향

    protected WeaponRenderer _weaponRenderer;
    protected Weapon _weapon;
    protected virtual void Awake()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position; // 마우스 방향 벡터를 구한다.

        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //디그리(세타) 각도 구하기

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward);
        //z축 기준으로 회전
        AdjustWeaponRendering();
    }

    private void AdjustWeaponRendering()
    {
        if(_weaponRenderer != null)
        {
            _weaponRenderer.FlipSpriter(_desireAngle > 90 || _desireAngle < -90);
            _weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180);
        }
    }
    public virtual void Shoot()
    {
        _weapon?.TryShooting();
    }
    public virtual void StopShooting()
    {
        _weapon?.StopShooting();
    }
}
