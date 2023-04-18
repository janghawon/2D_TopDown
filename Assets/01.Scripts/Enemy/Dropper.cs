using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Dropper : MonoBehaviour
{
    [SerializeField] private ItemDropTableSo _dropTable;
    [SerializeField] private ItemDropTableSo _coinDropTable;
    private float[] _itemWeights;

    [SerializeField] private bool _dropEffect = false;
    [SerializeField] private float _dropPower = 2f;

    [SerializeField] [Range(0, 1)] private float _dropChance;

    private void Start()
    {
        _itemWeights = _dropTable.DropList.Select(item => item.Rate).ToArray();
    }

    public void DropItem()
    {
        float dropVariable = Random.value;
        if(dropVariable < _dropChance)
        {
            int idx = GetRandomWeightIndex();
            ItemScript item = PoolManager.Instance.Pop(_dropTable.DropList[idx].ItemPrefab.name) as ItemScript;

            item.transform.position = transform.position;

            if(_dropEffect)
            {
                Vector3 offset = Random.insideUnitCircle * 1.5f;
                item.transform.DOJump(transform.position + offset, _dropPower, 1, 0.35f);
            }
        }
    }

    public void CoinDrop()
    {
        ItemScript item = PoolManager.Instance.Pop(_coinDropTable.DropList[0].ItemPrefab.name) as ItemScript;
        item.transform.position = transform.position;

        if (_dropEffect)
        {
            Vector3 offset = Random.insideUnitCircle * 1.5f;
            item.transform.DOJump(transform.position + offset, _dropPower, 1, 0.35f);
        }
    }

    private int GetRandomWeightIndex()
    {
        float sum = 0;
        for(int i = 0; i < _itemWeights.Length; i++)
        {
            sum += _itemWeights[i];
        }

        float randomValue = Random.Range(0, sum);
        float tempSum = 0;

        for(int i = 0; i < _itemWeights.Length; i++)
        {
            if (randomValue >= tempSum && randomValue < tempSum + _itemWeights[i])
                return i;
            else
                tempSum += _itemWeights[i];
        }

        return 0;
    }
}
