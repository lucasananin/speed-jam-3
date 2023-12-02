using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [Title("// General")]
    [SerializeField] LineRenderer _lineRenderer = null;
    [SerializeField] Collider2D _collider = null;
    //[SerializeField] bool _isEnabled = true;

    [Title("// States")]
    [SerializeField] bool _isMalfunctioning = false;
    [SerializeField] bool _isOn = true;
    [SerializeField] float _timeOn = 2f;
    [SerializeField] float _timeOff = 4f;
    [SerializeField, ReadOnly] float _nextState = 0f;

    [Title("// Damage")]
    [SerializeField] float _damage = 99;

    private void Awake()
    {
        _nextState = 0f;
    }

    private void Update()
    {
        if (!_isMalfunctioning) return;

        _nextState += Time.deltaTime;

        if (_isOn && _nextState > _timeOn)
        {
            _nextState = 0;
            _isOn = !_isOn;
            DisableVisuals();
        }
        else if (!_isOn && _nextState > _timeOff)
        {
            _nextState = 0;
            _isOn = !_isOn;
            EnableVisuals();
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            _other.GetComponent<HealthSystem>().TakeDamage(_damage);
        }
    }

    public void EnableVisuals()
    {
        _lineRenderer.enabled = true;
        _collider.enabled = true;
    }

    public void DisableVisuals()
    {
        _lineRenderer.enabled = false;
        _collider.enabled = false;
    }
}
