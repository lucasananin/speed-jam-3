using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem = null;
    [SerializeField] bool _isShield = false;
    [SerializeField] bool _isBoss = false;

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

        if (_isBoss && LoadSceneManager.Instance != null)
        {
            LoadSceneManager.Instance.LoadScene("Leaderboard");
        }

        gameObject.SetActive(false);
    }
}
