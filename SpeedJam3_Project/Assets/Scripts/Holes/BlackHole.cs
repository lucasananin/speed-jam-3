using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] SpriteRenderer _areaEffectSprite = null;
    [SerializeField] bool _isPullType = true;
    [SerializeField] float _radius = 2f;
    [SerializeField] float _forceMultiplier = 1;

    private void Awake()
    {
        _areaEffectSprite.transform.localScale = Vector3.one * (_radius * 2);
    }

    private void Update()
    {
        var _colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

        int _count = _colliders.Length;

        for (int i = 0; i < _count; i++)
        {
            if (_colliders[i].gameObject.CompareTag("Player"))
            {
                var _playerMovement = _colliders[i].GetComponent<PlayerMovement>();

                var _direction = _isPullType ?
                    (transform.position - _playerMovement.transform.position).normalized :
                    (_playerMovement.transform.position - transform.position).normalized;

                _playerMovement.AddForce(_direction, _forceMultiplier);
            }
        }
    }
}
