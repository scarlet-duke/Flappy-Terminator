using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _spawnDistance = 2f;
    [SerializeField] private SpawnerBullet _spawnerBullet;

    public void SetSpawnerBullet(SpawnerBullet spawnerBullet)
    {
        _spawnerBullet = spawnerBullet;
    }

    public void Shoot()
    {
        Vector3 spawnPosition = transform.position + transform.right * _spawnDistance;
        Quaternion spawnRotation = transform.rotation;
        _spawnerBullet.SpawnBullet(spawnPosition, spawnRotation, transform.right);
    }
}