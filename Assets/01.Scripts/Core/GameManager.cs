using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private poolableMono _bulletPrefab;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Makepool();
    }
    private void Makepool()
    {
        PoolManager.Instance = new PoolManager(transform);
        PoolManager.Instance.CreatePool(_bulletPrefab, 20);
    }
}
