using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] GameObject _defaultMenu = null;
    [SerializeField] GameObject _insertNameMenu = null;

    private IEnumerator Start()
    {
        while (!LootLockerSDKManager.CheckInitialized())
        {
            yield return null;
        }

        if (!_playerDataSO.HasSetName())
        {
            _defaultMenu.SetActive(false);
            _insertNameMenu.SetActive(true);
        }
        else
        {
            _defaultMenu.SetActive(true);
            _insertNameMenu.SetActive(false);
        }
    }
}
