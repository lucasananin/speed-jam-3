using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
{
    [SerializeField] float _damage = 1;
    [SerializeField] float _attackRadius = 1;
    [SerializeField] float _attackRate = 1;
    [SerializeField, ReadOnly] float _nextAttack = 0;
    [SerializeField] SpriteRenderer _attackAreaSprite = null;

    private void Update()
    {
        if (_nextAttack < _attackRate)
        {
            _nextAttack += Time.deltaTime;
        }

        if (_nextAttack > _attackRate)
        {
            _nextAttack -= _attackRate;

            var _colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius);
            int _count = _colliders.Length;

            for (int i = 0; i < _count; i++)
            {
                if (_colliders[i].gameObject.CompareTag("Player"))
                {
                    _colliders[i].GetComponent<HealthSystem>().TakeDamage(_damage);
                }
            }
        }

        if (_attackAreaSprite != null)
        {
            _attackAreaSprite.transform.localScale = Vector3.one * _attackRadius * 2;
        }
    }
}
