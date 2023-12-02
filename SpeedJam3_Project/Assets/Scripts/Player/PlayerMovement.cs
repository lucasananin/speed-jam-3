using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Title("// General")]
    [SerializeField] PlayerWeapon _playerWeapon = null;
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] bool _resetVelocityOnShoot = false;

    [Title("// Impulse Back")]
    [SerializeField] float _impulseForceMultiplier = 10f;

    [Title("// Input Movement")]
    [SerializeField] bool _useInput = false;
    [SerializeField] float _xInput = 0;
    [SerializeField] float _yInput = 0;
    [SerializeField] float _moveSpeed = 1f;

    private void OnEnable()
    {
        _playerWeapon.onShoot += ImpulseBack;
    }

    private void OnDisable()
    {
        _playerWeapon.onShoot -= ImpulseBack;
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!_useInput) return;

        var _direction = new Vector2(_xInput, _yInput);
        var _velocity = _direction * _moveSpeed * Time.deltaTime;
        _rb.velocity += _velocity;
    }

    private void ImpulseBack()
    {
        if (_resetVelocityOnShoot)
        {
            _rb.velocity = Vector3.zero;
        }

        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;

        Vector3 _impulseDirection = (transform.position - _mousePosition).normalized;
        Vector3 _velocity = _impulseDirection * _impulseForceMultiplier;
        _rb.AddForce(_velocity, ForceMode2D.Impulse);
    }

    public void AddForce(Vector3 _direction, float _multiplier)
    {
        Vector3 _velocity = _direction * _multiplier;
        _rb.AddForce(_velocity, ForceMode2D.Force);
    }
}
