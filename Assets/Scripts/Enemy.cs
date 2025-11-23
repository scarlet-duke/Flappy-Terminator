using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Life _life;

    public event Action<Enemy> Disappeard;
    private WaitForSeconds _waitForSeconds;
    private float _left = 180;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_repeatRate);
        transform.rotation = Quaternion.Euler(0, _left, 0);
    }

    private void OnEnable()
    {
        _life.Death += Disappear;
        StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        _life.Death -= Disappear;
    }

    private IEnumerator StartShooting()
    {
        while (enabled)
        {
            yield return _waitForSeconds;
            _shooter.Shoot();
        }
    }

    private void Disappear()
    {
        Disappeard?.Invoke(this);
    }

    public void SetSpawnerBullet(SpawnerBullet spawnerBullet)
    {
        _shooter.SetSpawnerBullet(spawnerBullet);
    }
}
