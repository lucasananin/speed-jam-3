using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _maxHealth = 3;
    [SerializeField, ReadOnly] float _currentHealth = 0;

    public event Action onDamageTaken = null;
    public event Action onDead = null;

    private void Start()
    {
        ResetHealth();
    }

    [Button]
    private void TakeDamage()
    {
        TakeDamage(1);
    }

    public void TakeDamage(float _value)
    {
        _currentHealth -= _value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            onDead?.Invoke();
        }
        else
        {
            onDamageTaken?.Invoke();
        }
    }

    [Button]
    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    [Button]
    private void Revive()
    {
        ResetHealth();
        gameObject.SetActive(true);
    }
}
