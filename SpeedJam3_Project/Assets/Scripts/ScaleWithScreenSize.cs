using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithScreenSize : MonoBehaviour
{
    private void Start()
    {
        Set();   
    }

    [Button]
    public void Set()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        float height = ScreenSize.GetScreenToWorldHeight;
        transform.localScale = new Vector3(width, height, 0);
        //transform.localScale = Vector3.one * width;
    }
}
