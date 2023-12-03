using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    //[SerializeField] PlayerDataSO _playerDataSo = null;
    [SerializeField] float _timeInSeconds = 0;

    private void Update()
    {
        _timeInSeconds += Time.deltaTime;
        //Debug.Log(GetTimeString());
    }

    public string GetTimeString()
    {
        int seconds = ((int)_timeInSeconds % 60);
        int minutes = ((int)_timeInSeconds / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
