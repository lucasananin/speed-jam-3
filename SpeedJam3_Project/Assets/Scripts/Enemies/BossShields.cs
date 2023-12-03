using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShields : MonoBehaviour
{
    [SerializeField] float _rotation = 15f;

    private void Update()
    {
        transform.Rotate(0, 0, _rotation * Time.deltaTime);
    }
}
