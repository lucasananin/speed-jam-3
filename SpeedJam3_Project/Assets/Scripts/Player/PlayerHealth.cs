using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem = null;

    public static event Action onPlayerTakeDamage = null;
    public static event Action onPlayerDead = null;

    private void OnEnable()
    {
        _healthSystem.onDead += Die;
        _healthSystem.onDamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        _healthSystem.onDead -= Die;
        _healthSystem.onDamageTaken -= TakeDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _healthSystem.Die();
        }
    }

    private void TakeDamage()
    {
        onPlayerTakeDamage?.Invoke();
    }

    private void Die()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayDefeatSfx();
        }

        //Application.LoadLevel(Application.loadedLevel);
        gameObject.SetActive(false);
        onPlayerDead?.Invoke();
    }

    public void BecomeInvincible()
    {
        _healthSystem.IsInvincible = true;
    }
}
