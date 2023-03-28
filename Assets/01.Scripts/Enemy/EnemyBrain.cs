using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : MonoBehaviour
{
    public Transform Target;

    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChanged;

    public Transform BasePosition;
    public AIState currentState;

    private void Start()
    {
        Target = GameManager.Instance.PlayerTrm;
        currentState?.SetUp(transform);
    }
    public void ChangeState(AIState nextState)
    {
        currentState = nextState;
        currentState.SetUp(transform);
    }

    public void Update()
    {
        if(Target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero);
        }
        else
        {
            currentState.UpdateState();
        }
    }

    public void Move(Vector2 moveDir, Vector2 targetPosition)
    {
        OnMovementKeyPress?.Invoke(moveDir);
        OnPointerPositionChanged?.Invoke(targetPosition);
    }
}
