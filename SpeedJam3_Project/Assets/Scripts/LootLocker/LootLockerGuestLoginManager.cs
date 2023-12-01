using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootLockerGuestLoginManager : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;

    private void Start()
    {
        StartGuestSession();
    }

    public void StartGuestSession()
    {
        _playerDataSO.LoadPlayerId();

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                _playerDataSO.SetPlayerId(response.player_id.ToString());
                Debug.Log("successfully started LootLocker session");
            }
            else
            {
                _playerDataSO.SetPlayerId(null);
                Application.Quit();
                Debug.Log("error starting LootLocker session");
            }
        });
    }
}
