using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public event Action Death;

    public void Die()
    {
        Death?.Invoke();
    }
}
