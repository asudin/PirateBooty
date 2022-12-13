using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

[Serializable]
public class ObjectPoolItem
{
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _amountToPool;
    [SerializeField] private bool _isExpandable = true;

    public GameObject ObjectToPool => _objectToPool;
    public int AmountToPool => _amountToPool;
    public bool IsExpandable => _isExpandable;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolItem> _itemsToPool;
    [SerializeField] private List<GameObject> _pooledObjects;

    public static ObjectPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in _itemsToPool)
        {
            for (int i = 0; i < item.AmountToPool; i++)
            {
                GameObject spawned = Instantiate(item.ObjectToPool);
                spawned.SetActive(false);
                _pooledObjects.Add(spawned);
            }
        }
    }

    public GameObject TryGetPooledObject(string label)
    {
        foreach (GameObject spawned in _pooledObjects)
        {
            if (!spawned.activeInHierarchy && spawned.tag == label)
                return spawned;
        }

        foreach (ObjectPoolItem item in _itemsToPool)
        {
            if (item.ObjectToPool.tag == label && item.IsExpandable)
            {
                GameObject spawned = Instantiate(item.ObjectToPool);
                spawned.SetActive(false);
                _pooledObjects.Add(spawned);
                return spawned;
            }
        }
        return null;
    }
}
