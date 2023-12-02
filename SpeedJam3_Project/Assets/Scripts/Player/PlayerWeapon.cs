using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    [SerializeField] float _impulseForceMultiplier = 10f;

    public event Action onShoot = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;

        Bullet _bullet = Instantiate(_bulletPrefab, _shootOrigin.position, Quaternion.identity);
        _bullet.gameObject.SetActive(true);

        Vector3 _impulseDirection = (_mousePosition - transform.position).normalized;
        _bullet.AddImpulse(_impulseDirection, _impulseForceMultiplier);

        onShoot?.Invoke();
    }
}
