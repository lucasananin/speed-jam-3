using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
