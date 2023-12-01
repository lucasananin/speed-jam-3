using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpulseTest : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] float _impulseForceMultiplier = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;

            Vector3 _impulseDirection = (transform.position - _mousePosition).normalized;
            Vector3 _velocity = _impulseDirection * _impulseForceMultiplier;
            _rb.AddForce(_velocity, ForceMode2D.Impulse);
        }
    }
}
