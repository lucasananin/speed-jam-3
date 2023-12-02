using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField, ReadOnly] HealthSystem _playerHealth = null;
    [Space]
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _rotationSpeed = 10f;
    [Space]
    [SerializeField] bool _isAlert = false;
    [SerializeField] float _alertDistance = 5f;
    [SerializeField] float _stoppingDistance = 0.1f;

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
            if (_distance < _stoppingDistance) return;

            var _direction = (_playerHealth.transform.position - transform.position).normalized;
            var _velocity = _direction * _moveSpeed;
            _rb.velocity = _velocity;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }

        if (_rb.velocity != Vector2.zero)
        {
            Vector3 _dir = (_playerHealth.transform.position - transform.position).normalized;
            float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
            Quaternion _newRot = Quaternion.AngleAxis(_angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _newRot, _rotationSpeed * Time.deltaTime);
        }
    }
}
