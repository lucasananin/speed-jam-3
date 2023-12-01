using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _playerTransform = null;

    private void LateUpdate()
    {
        if (_playerTransform != null)
        {
            transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, -10);
        }
    }
}
