using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] SpriteRenderer _alertAreaCircle = null;
    [SerializeField, ReadOnly] HealthSystem _playerHealth = null;
    [Space]
    [SerializeField] float _rotationSpeed = 10f;
    [Space]
    [SerializeField] bool _isAlert = false;
    [SerializeField] float _alertDistance = 5f;

    public bool IsAlert { get => _isAlert; private set => _isAlert = value; }
    public HealthSystem PlayerHealth { get => _playerHealth; private set => _playerHealth = value; }

    private void Awake()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
    }

    private void Update()
    {
        if (_playerHealth == null) return;

        float _distance = (_playerHealth.transform.position - transform.position).magnitude;

        _isAlert = _distance < _alertDistance;

        if (_isAlert)
        {
            Vector3 _dir = (_playerHealth.transform.position - transform.position).normalized;
            float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
            Quaternion _newRot = Quaternion.AngleAxis(_angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _newRot, _rotationSpeed * Time.deltaTime);
        }

        if (_alertAreaCircle != null)
        {
            _alertAreaCircle.transform.localScale = Vector3.one * _alertDistance * 2;
        }
    }
}
