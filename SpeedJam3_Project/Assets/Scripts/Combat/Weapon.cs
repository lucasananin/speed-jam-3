using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab = null;
    [SerializeField] protected Transform _shootOrigin = null;

    public abstract void Shoot();
}
