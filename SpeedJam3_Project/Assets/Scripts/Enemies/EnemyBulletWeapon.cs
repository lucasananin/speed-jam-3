using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletWeapon : Weapon
{
    [SerializeField] Enemy2 _enemy2 = null;

    private void Awake()
    {
        _nextFire = 0f;
    }

    private void FixedUpdate()
    {
        if (!_enemy2.IsAlert)
        {
            _nextFire = 0;
            return;
        }

        if (_nextFire < _fireRate)
        {
            _nextFire += Time.fixedDeltaTime;
        }

        if (_nextFire >= _fireRate)
        {
            _nextFire -= _fireRate;
            Shoot();
        }
    }

    public override void Shoot()
    {
        if (_shootPoints.Count == 0)
        {
            Bullet _bullet = Instantiate(_bulletPrefab, _shootOrigin.position, Quaternion.identity);

            Vector3 _impulseDirection = (_enemy2.PlayerHealth.transform.position - transform.position).normalized;
            _bullet.AddImpulse(_impulseDirection, _impulseForceMultiplier);
            SpawnMuzzleFlash();
        }
        else
        {
            int _count = _shootPoints.Count;

            for (int i = 0; i < _count; i++)
            {
                Bullet _bullet = Instantiate(_bulletPrefab, _shootPoints[i].position, Quaternion.identity);

                //Vector3 _impulseDirection = (_enemy2.PlayerHealth.transform.position - transform.position).normalized;
                //_bullet.AddImpulse(_impulseDirection, _impulseForceMultiplier);
                _bullet.AddImpulse(_shootPoints[i].up, _impulseForceMultiplier);
                SpawnMuzzleFlash();
            }
        }
    }
}
