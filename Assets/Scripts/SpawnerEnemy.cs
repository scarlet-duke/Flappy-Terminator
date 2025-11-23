using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeatRate = 1.5f;
    [SerializeField] private float _randomCoordinate = 3f;
    [SerializeField] private SpawnerBullet _spawnerBullet;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_repeatRate);
        StartCoroutine(StartSpawning());
    }

    private void SpawnEnemy()
    {
        Enemy obj = Get();
        obj.transform.position = new Vector3(transform.position.x, Random.Range(-_randomCoordinate, _randomCoordinate), 0f);
        obj.SetSpawnerBullet(_spawnerBullet);
        obj.gameObject.SetActive(true);
        obj.Disappeard += OnRelease;
    }

    private void OnRelease(Enemy obj)
    {
        obj.Disappeard -= OnRelease;
        Release(obj);
    }

    private IEnumerator StartSpawning()
    {
        while (enabled)
        {
            SpawnEnemy();
            yield return _waitForSeconds;
        }
    }
}
