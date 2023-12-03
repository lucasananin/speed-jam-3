using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem = null;
    [SerializeField] TextMeshProUGUI _healthText = null;

    private void Awake()
    {
        if (_healthSystem == null)
        {
            _healthSystem = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
        }
    }

    private void LateUpdate()
    {
        _healthText.text = $"{_healthSystem.CurrentHealth}";
    }
}
