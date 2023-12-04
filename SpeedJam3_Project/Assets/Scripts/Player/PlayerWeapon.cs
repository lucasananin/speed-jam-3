using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    [Title("// Player Weapon")]
    [SerializeField] bool _isHoldingShootButton = false;
    [SerializeField] float _bulletAngle = 3f;

    public event Action onShoot = null;

    private void Awake()
    {
        _nextFire = 0f;
    }

    private void Update()
    {
        _isHoldingShootButton = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        if (_nextFire < _fireRate)
        {
            _nextFire += Time.fixedDeltaTime;
        }

        if (_isHoldingShootButton && _nextFire >= _fireRate)
        {
            _nextFire -= _fireRate;
            Shoot();
        }
    }

    public override void Shoot()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;

        Bullet _bullet = Instantiate(_bulletPrefab, _shootOrigin.position, Quaternion.identity);

        float _randomAngle = UnityEngine.Random.Range(-_bulletAngle, _bulletAngle);
        _mousePosition += transform.up * _randomAngle;

        Vector3 _impulseDirection = (_mousePosition - transform.position).normalized;
        _bullet.AddImpulse(_impulseDirection, _impulseForceMultiplier);

        PlayMuzzleFlashVfx();
        PlayRecoilVfx();
        PlaySfx();
        onShoot?.Invoke();
    }
}
