using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
    [SerializeField] float _damage = 99;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        //if (_other.gameObject.CompareTag("Player"))
        //{
        //    _other.GetComponent<HealthSystem>().TakeDamage(_damage);
        //}

        if (_other.gameObject.TryGetComponent(out HealthSystem _healthSystem))
        {
            _healthSystem.TakeDamage(_damage);
        }
    }
}
