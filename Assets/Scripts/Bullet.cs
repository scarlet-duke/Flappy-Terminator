using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _lifeWatch = 5f;

    public event Action<Bullet> Disappeard;
    private WaitForSeconds _waitForSeconds;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifeWatch);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        StartCoroutine(LifeWatcher());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Life life))
        {
            life.Die();
            Disappear();
        }
    }

    private IEnumerator LifeWatcher()
    {
        yield return _waitForSeconds;
        Disappear();
    }

    private void Disappear()
    {
        Disappeard?.Invoke(this);
    }
}
