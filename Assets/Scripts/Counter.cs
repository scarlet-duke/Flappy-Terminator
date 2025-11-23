using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;

    private int _count;

    private void OnEnable()
    {
        _spawnerEnemy.ReturnToThePool += LogAction;
    }

    private void OnDisable()
    {
        _spawnerEnemy.ReturnToThePool -= LogAction;
    }

    public void LogAction(int count)
    {
        _count = count;
        _text.text = _count + "";
    }
}
