using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;
    private Dictionary<string, Pool<poolableMono>> _pools = new Dictionary<string, Pool<poolableMono>>();


}
