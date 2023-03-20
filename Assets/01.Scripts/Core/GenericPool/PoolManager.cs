using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;
    private Dictionary<string, Pool<poolableMono>> _pools = new Dictionary<string, Pool<poolableMono>>();

    private Transform _transParent;
    public PoolManager(Transform trmParent)
    {
        _transParent = trmParent;
    }

    public void CreatePool(poolableMono prefab, int count)
    {
        Pool<poolableMono> pool = new Pool<poolableMono>(prefab, _transParent, count);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public poolableMono Pop(string prefabName)
    {
        if(_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError(11);
            return null;
        }

        poolableMono item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }

    public void Push(poolableMono obj)
    {
        _pools[obj.name].Push(obj);
    }
}
