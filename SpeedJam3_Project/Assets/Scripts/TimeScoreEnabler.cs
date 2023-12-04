using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScoreEnabler : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSo = null;

    private void Start()
    {
        _playerDataSo.CanCountTime = true;
    }
}
