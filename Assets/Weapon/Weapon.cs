using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponDataSo _weaponDataSO;
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected Transform _shellEjectPosition;

    public WeaponDataSo WeaponData => _weaponDataSO;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmon;
    public UnityEvent OnStopShooting;
    protected bool _isShooting;
    protected bool _delayCorouine = false;

    #region AMMO 관련 코드들
    protected int _ammo;
    public int Ammo
    {
        get { return _ammo; }
        set
        {
            _ammo = Mathf.Clamp(value, 0, WeaponData.ammoCapcity);
        }
    }
    public bool AmooFull => Ammo == WeaponData.ammoCapcity;
    public int EmptyBulletCnt => WeaponData.ammoCapcity - _ammo;
    #endregion

    private void Awake()
    {
        _ammo = WeaponData.ammoCapcity;
    }

    private void Update()
    {
        UseWeapon();
    }

    public void UseWeapon()
    {
        if (_isShooting && _delayCorouine == false)
        {
            if (Ammo > _weaponDataSO.bulletCount)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < _weaponDataSO.bulletCount; i++)
                {
                    ShootBullet();
                    Ammo--;
                }
            }
            else
            {
                _isShooting = false;
                OnShootNoAmmon?.Invoke();
                return;
            }
            FinishOneShooting();
        }
    }

    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCorutine());
        if (_weaponDataSO.autoFire == false)
        {
            _isShooting = false;
        }
    }

    private IEnumerator DelayNextShootCorutine()
    {
        _delayCorouine = true;
        yield return new WaitForSeconds(_weaponDataSO.weaponDelay);
        _delayCorouine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(_muzzle.position, CalculateAngle(_muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        RegularBullet b = PoolManager.Instance.Pop("Bullet") as RegularBullet;
        b.SetPositionAndRotation(position, rotation);
        b.IsEnemy = false;
    }

    private Quaternion CalculateAngle(Transform muzzle)
    {
        float spread = Random.Range(-_weaponDataSO.spreadAngle, _weaponDataSO.spreadAngle);
        Quaternion bulletSpreadRot = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRot;
    }

    public void TryShooting()
    {
        _isShooting = true;
    }

    public void StopShooting()
    {
        _isShooting = false;
        OnStopShooting?.Invoke();
    }

}