using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Weapon : MonoBehaviour
{
    [Title("// Muzzle Vfx")]
    [SerializeField] protected Bullet _bulletPrefab = null;
    [SerializeField] protected Transform _shootOrigin = null;
    [SerializeField] protected List<Transform> _shootPoints = null;
    [SerializeField] protected float _impulseForceMultiplier = 10f;
    [SerializeField] protected float _fireRate = 0.1f;
    [SerializeField, ReadOnly] protected float _nextFire = 0f;
    
    [Title("// Muzzle Vfx")]
    [SerializeField] protected Transform _muzzlePoint = null;
    [SerializeField] protected List<Transform> _muzzlePoints = null;
    [SerializeField] protected ParticleSystem _muzzleFlashVfx = null;

    [Title("// Recoil Vfx")]
    [SerializeField] Transform _weaponTransform = null;
    [SerializeField] float _recoil = 0.1f;
    [SerializeField] float _duration = 0.3f;

    public abstract void Shoot();

    public virtual void PlayMuzzleFlashVfx()
    {
        if (_muzzleFlashVfx == null) return;

        if (_muzzlePoints.Count == 0)
        {
            var _p = Instantiate(_muzzleFlashVfx, _muzzlePoint.position, _muzzlePoint.rotation, _muzzlePoint);
            _p.Play();
        }
        else
        {
            int _count = _muzzlePoints.Count;

            for (int i = 0; i < _count; i++)
            {
                var _p = Instantiate(_muzzleFlashVfx, _muzzlePoints[i].position, _muzzlePoints[i].rotation, _muzzlePoints[i]);
                _p.Play();
            }
        }
    }

    public virtual void PlayRecoilVfx()
    {
        if (_weaponTransform == null) return;

        _weaponTransform.DOComplete();
        _weaponTransform.localPosition += Vector3.left * _recoil;
        _weaponTransform.DOLocalMoveX(0, _duration);
    }

    public virtual void PlaySfx()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayShootSfx();
        }
    }
}
