using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityTest : MonoBehaviour
{
    [SerializeField] List<Vector2> _gravityList = null;
    [SerializeField] int _gravityIndex = 0;

    private void Start()
    {
        Physics2D.gravity = _gravityList[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _gravityIndex++;

            if (_gravityIndex >= _gravityList.Count)
            {
                _gravityIndex = 0;
            }

            Physics2D.gravity = _gravityList[_gravityIndex];
        }
    }
}
