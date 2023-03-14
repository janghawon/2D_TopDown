using System;
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

    #region AMMO 包访 内靛甸
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
            if (Ammo > 0)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < _weaponDataSO.bulletCount; i++)
                {
                    ShootBullet();
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
        Debug.Log("葛贰馆瘤 户具户具");
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