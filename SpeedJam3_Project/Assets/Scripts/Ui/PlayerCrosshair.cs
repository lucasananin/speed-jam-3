using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] RectTransform _rect = null;

    private void LateUpdate()
    {
        _rect.position = Input.mousePosition;
    }
}
