using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _amount;

    private List<T> _pool = new List<T>();

    protected void Initialize(List<T> prefab)
    {
        for (int i = 0; i < _amount; i++)
        {
            T spawned = Instantiate(prefab[Random.Range(0, prefab.Count)], _container);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
    }
}

    protected bool TryGetObjectInPool(out T result)
    {
        T gameObject = _pool.FirstOrDefault(poolObject => poolObject.gameObject.activeSelf == false);
        result = gameObject;
        return result != null;
    }
}
