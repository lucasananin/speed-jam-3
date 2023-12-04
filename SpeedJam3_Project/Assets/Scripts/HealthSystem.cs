using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] bool _isInvincible = false;
    [SerializeField] float _maxHealth = 3;
    [SerializeField, ReadOnly] float _currentHealth = 0;

    [Title("// Vfx")]
    [SerializeField] List<SpriteRenderer> _spriteRenderers = null;
    [SerializeField] float _duration = 0.1f;

    public event Action onDamageTaken = null;
    public event Action onDead = null;

    public float CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }

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
        if (_isInvincible) return;

        _currentHealth -= _value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            onDead?.Invoke();
        }
        else
        {
            PlayTakeDamageColorVfx();
            onDamageTaken?.Invoke();
        }
    }

    private void PlayTakeDamageColorVfx()
    {
        if (_spriteRenderers.Count <= 0) return;

        int _count = _spriteRenderers.Count;

        for (int i = 0; i < _count; i++)
        {
            _spriteRenderers[i].DOComplete();
            _spriteRenderers[i].color = Color.red;
            _spriteRenderers[i].DOColor(Color.white, _duration);
        }
    }

    [Button]
    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    [Button]
    private void Die()
    {
        TakeDamage(_currentHealth);
    }

    [Button]
    private void Revive()
    {
        ResetHealth();
        gameObject.SetActive(true);
    }
}
