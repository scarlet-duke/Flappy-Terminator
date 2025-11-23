using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _t;

    private ObjectPool<T> _pool;
    private int _count = 0;
    public event Action<int> ReturnToThePool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => CreateFuncSpawner(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnReleaseSpawner(obj));
    }

    private T CreateFuncSpawner()
    {
        return Instantiate(_t);
    }

    private void ActionOnReleaseSpawner(T obj)
    {
        _count++;
        ReturnToThePool?.Invoke(_count);
        obj.gameObject.SetActive(false);
    }

    private void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }
}