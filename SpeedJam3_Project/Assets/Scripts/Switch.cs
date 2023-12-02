using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] bool _isActivated = false;
    [SerializeField] UnityEvent _onEnabled = null;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_isActivated) return;

        //if (_other.gameObject.CompareTag("Player"))
        //{
        //    _isActivated = true;
        //    _spriteRenderer.color = Color.green;
        //    _onEnabled?.Invoke();
        //}

        _isActivated = true;
        _spriteRenderer.color = Color.green;
        _onEnabled?.Invoke();
    }
}
