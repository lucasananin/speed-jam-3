using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] RectTransform _rect = null;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }

    private void LateUpdate()
    {
        _rect.position = Input.mousePosition;
    }
}
