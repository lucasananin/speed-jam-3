using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem = null;
    [SerializeField] bool _isShield = false;

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
        if (_isShield && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCrackedShieldSfx();
        }

        gameObject.SetActive(false);
    }
}
