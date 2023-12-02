using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class LookAtMouse : MonoBehaviour
    {
        [SerializeField] bool _rotate = true;
        //[SerializeField] float _rotationSpeed = 10f;
        [Space]
        [SerializeField] bool _flipX = true;
        [SerializeField] bool _flipY = true;
        [Space]
        [SerializeField, ReadOnly] Camera _camera = null;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (_rotate)
            {
                Vector3 _dir = (_mousePosition - transform.position).normalized;
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
                //Quaternion _newRot = Quaternion.AngleAxis(_angle, Vector3.forward);
                //transform.rotation = Quaternion.Slerp(transform.rotation, _newRot, _rotationSpeed * Time.deltaTime);
            }

            if (_flipX || _flipY)
            {
                bool _isLookingToTheRight = _camera.WorldToViewportPoint(_mousePosition).x > 0.5f;
                int _xScale = _isLookingToTheRight ? 1 : -1;
                int _yScale = _isLookingToTheRight ? 1 : -1;
                transform.localScale = new Vector3(_flipX ? _xScale : 1, _flipY ? _yScale : 1, 1);
            }
        }
    }
}