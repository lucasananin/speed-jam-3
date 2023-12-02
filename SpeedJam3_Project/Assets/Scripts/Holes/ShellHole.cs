using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHole : MonoBehaviour
{
    [SerializeField] BoxCollider2D _areaEffectCollider = null;
    [SerializeField] bool _isPullType = true;
    [SerializeField] float _forceMultiplier = 1;

    private void Update()
    {
        var _colliders = Physics2D.OverlapBoxAll(_areaEffectCollider.transform.position, _areaEffectCollider.transform.localScale, 0);

        int _count = _colliders.Length;

        for (int i = 0; i < _count; i++)
        {
            if (_colliders[i].gameObject.CompareTag("Player"))
            {
                Debug.Log($"fodase");
                var _playerMovement = _colliders[i].GetComponent<PlayerMovement>();

                var _direction = _isPullType ?
                    (transform.position - _playerMovement.transform.position).normalized :
                    (_playerMovement.transform.position - transform.position).normalized;

                _playerMovement.AddForce(_direction, _forceMultiplier);
            }
        }
    }
}
