using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PoolingListSO _poolingList;
    public static GameManager Instance;

    [SerializeField] private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        TimeController.Instance = transform.AddComponent<TimeController>();

        Makepool();
    }
    private void Makepool()
    {
        PoolManager.Instance = new PoolManager(transform);
        _poolingList.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
        
    }
}
