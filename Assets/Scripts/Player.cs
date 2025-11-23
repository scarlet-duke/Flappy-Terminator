using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BirdMover _jumper;
    [SerializeField] private Shooter _shooter;

    private void OnEnable()
    {
        _inputReader.Jump += Jump;
        _inputReader.Shoot += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.Jump -= Jump;
        _inputReader.Shoot -= Shoot;
    }

    private void Jump()
    {
        _jumper.Jump();
    }

    private void Shoot()
    {
        _shooter.Shoot();
    }
}
