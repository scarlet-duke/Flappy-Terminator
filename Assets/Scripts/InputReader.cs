using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Jump;
    public event Action Shoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot?.Invoke();
        }
    }
}
