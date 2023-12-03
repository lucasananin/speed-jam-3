using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] bool _isPlayerBullet = true;
    [SerializeField] float _damage = 1;
    //[Space]
    //[SerializeField] float _finalScale = 1f;
    //[SerializeField] float _scaleDuration = 1f;

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPlayerBullet && collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out HealthSystem _healthSystem))
        {
            _healthSystem.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isPlayerBullet && collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out HealthSystem _healthSystem))
        {
            _healthSystem.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    public void AddImpulse(Vector3 _direction, float _multiplier)
    {
        var _velocity = _direction * _multiplier;
        _rb.AddForce(_velocity, ForceMode2D.Impulse);
        //transform.DOScale(_finalScale, _scaleDuration);
    }
}
