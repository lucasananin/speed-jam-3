using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootLockerManager : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;

    private void Start()
    {
        StartGuestSession();
        //StartCoroutine(StartGuestSession_routine());
    }

    public void StartGuestSession()
    {
        _playerDataSO.UserName = PlayerPrefs.GetString("PlayerId", null);

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                //_playerDataSO.HasLoggedIn = true;
                _playerDataSO.UserName = response.player_id.ToString();
                PlayerPrefs.SetString("PlayerId", _playerDataSO.UserName);
                Debug.Log("successfully started LootLocker session");
            }
            else
            {
                //_playerDataSO.HasLoggedIn = false;
                _playerDataSO.UserName = null;
                Application.Quit();
                Debug.Log("error starting LootLocker session");
            }
        });
    }

    //private IEnumerator StartGuestSession_routine()
    //{
    //    bool _isDone = false;

    //    _playerDataSO.UserName = PlayerPrefs.GetString("PlayerId", null);

    //    LootLockerSDKManager.StartGuestSession((response) =>
    //    {
    //        _isDone = true;

    //        if (response.success)
    //        {
    //            _playerDataSO.UserName = response.player_id.ToString();
    //            _playerDataSO.HasLoggedIn = true;
    //            PlayerPrefs.SetString("PlayerId", _playerDataSO.UserName);
    //            Debug.Log("successfully started LootLocker session");
    //        }
    //        else
    //        {
    //            _playerDataSO.UserName = null;
    //            _playerDataSO.HasLoggedIn = false;
    //            Application.Quit();
    //            Debug.Log("error starting LootLocker session");
    //        }
    //    });

    //    yield return new WaitWhile(() => !_isDone);
    //}
}
