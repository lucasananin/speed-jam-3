using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [Title("// General")]
    [SerializeField] LineRenderer _lineRenderer = null;
    [SerializeField] Collider2D _collider = null;
    //[SerializeField] bool _isEnabled = true;

    [Title("// Damage")]
    [SerializeField] float _damage = 99;

    //private void Update()
    //{
    //    _lineRenderer.enabled = _isEnabled;
    //    _collider.enabled = _isEnabled;
    //}

    public void EnableVisuals()
    {
        _lineRenderer.enabled = true;
        _collider.enabled = true;
    }

    public void DisableVisuals()
    {
        _lineRenderer.enabled = false;
        _collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            _other.GetComponent<HealthSystem>().TakeDamage(_damage);
        }
    }
}
