using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Agent/movementData")]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float _maxSpeed;

    [Range(0.1f, 100)]
    public float acceleration = 50, deAcceleration = 50;
}
