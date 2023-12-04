using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] PlayerDataSO _playerDataSo = null;
    [SerializeField] float _timeInSeconds = 0;

    private void Update()
    {
        if (!_playerDataSo.CanCountTime) return;

        _timeInSeconds += Time.deltaTime;
        _playerDataSo.Score = (int)_timeInSeconds;
        //Debug.Log(GetTimeString());
    }

    public string GetTimeString()
    {
        return GetTimeString(_timeInSeconds);
    }

    public string GetTimeString(float _value)
    {
        int seconds = ((int)_value % 60);
        int minutes = ((int)_value / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
