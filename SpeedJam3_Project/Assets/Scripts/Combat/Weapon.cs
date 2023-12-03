using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab = null;
    [SerializeField] protected Transform _shootOrigin = null;
    [SerializeField] protected float _impulseForceMultiplier = 10f;
    [SerializeField] protected float _fireRate = 0.1f;
    [SerializeField, ReadOnly] protected float _nextFire = 0f;

    public abstract void Shoot();
}
