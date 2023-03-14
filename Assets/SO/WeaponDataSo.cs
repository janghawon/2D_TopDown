using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Weapon/WeaponData")]
public class WeaponDataSo : ScriptableObject
{
    [Range(0, 999)] public int ammoCapcity = 100;
    public bool autoFire;

    [Range(0.1f, 2f)] public float weaponDelay = 0.1f;
    [Range(0, 10f)] public float spreadAngle = 5f;

    public int bulletCount = 1;
}