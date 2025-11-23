using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class SpawnerBullet : Spawner<Bullet>
{
    public void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation, Vector3 direction)
    {
        Bullet obj = Get();
        obj.transform.position = spawnPosition;
        obj.Move(direction);
        obj.Disappeard += OnRelease;
    }

    private void OnRelease(Bullet obj)
    {
        obj.Disappeard -= OnRelease;
        Release(obj);
    }
}