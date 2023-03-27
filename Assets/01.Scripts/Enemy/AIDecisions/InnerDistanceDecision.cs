using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistanceDecision : AIDecision
{
    public float Distance = 5f;

    public override bool MakeADescision()
    {
        Vector3 dis = _enemyBrain.Target.position - _enemyBrain.BasePosition.position;
        return dis.magnitude <= Distance;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }
    }

#endif
}
