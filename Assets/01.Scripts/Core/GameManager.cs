using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private PoolingListSO _poolingList;

    [SerializeField] private Transform _spawnPointParent;

    [SerializeField]
    private Transform _playerTrm; //�̰� ���߿� ã�ƿ��� �������� �����ؾ� ��.
    public Transform PlayerTrm => _playerTrm;

    private List<Transform> _spawnPointList;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple GameManager is running! Check!");
        }
        Instance = this;

        TimeController.Instance = transform.AddComponent<TimeController>();

        MakePool();
        _spawnPointList = new List<Transform>();
        _spawnPointParent.GetComponentsInChildren<Transform>(_spawnPointList);
        _spawnPointList.RemoveAt(0); // 0��°�� �θ�
    }


    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform); //Ǯ�Ŵ��� ������ְ�
        _poolingList.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));  
        
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float currentTime = 0;
        while(true)
        {
            currentTime += Time.deltaTime;
            //�������� �༭ �� 4~6������ ��������Ʈ �ݰ� 2������ ��������
            //���������� ������� ����
            if(currentTime >= 3)
            {
                currentTime = 0;
                int idx = Random.Range(0, _spawnPointList.Count);

                EnemyBrain enemy = PoolManager.Instance.Pop("EnemyGrowler") as EnemyBrain;

                enemy.transform.position = _spawnPointList[idx].position;
                enemy.ShowEnemy();
            }
            yield return null;
        }
    }
}
