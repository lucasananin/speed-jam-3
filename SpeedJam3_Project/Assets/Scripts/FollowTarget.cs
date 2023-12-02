using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform _targetTransform = null;
    [SerializeField] Vector3 _offset = Vector3.back;

    private void LateUpdate()
    {
        if (_targetTransform != null)
        {
            transform.position = _targetTransform.position + _offset;
        }
    }
}
