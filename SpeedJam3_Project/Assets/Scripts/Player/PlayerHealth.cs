using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem = null;

    public static event Action onPlayerDead = null;

    private void OnEnable()
    {
        _healthSystem.onDead += Die;
    }

    private void OnDisable()
    {
        _healthSystem.onDead -= Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
        onPlayerDead?.Invoke();
    }
}
