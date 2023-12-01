using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LootLocker.Requests;

public class LoginUiPanel : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] GameObject _loginPanel = null;
    [SerializeField] GameObject _loadingPanel = null;
    [SerializeField] TMP_InputField _inputField = null;
    [SerializeField] Button _confirmButton = null;
    [SerializeField] TextMeshProUGUI _errorMessageText = null;

    //private IEnumerator Start()
    //{
    //    while (!LootLockerSDKManager.CheckInitialized())
    //    {
    //        yield return null;
    //    }

    //    if (!_playerDataSO.HasSetName())
    //    {
    //        Show();
    //    }
    //    else
    //    {
    //        HideAll();
    //    }
    //}

    private void OnEnable()
    {
        _confirmButton.onClick.AddListener(SetPlayerName);
    }

    private void OnDisable()
    {
        _confirmButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        _confirmButton.interactable = _inputField.text.Length > 0;
        _errorMessageText.text = _playerDataSO.LoginErrorMessage;
    }

    public void SetPlayerName()
    {
        _playerDataSO.UserName = _inputField.text;
        ShowWaitPanel();

        LootLockerSDKManager.SetPlayerName(_playerDataSO.UserName.ToString(), (response) =>
        {
            if (response.success)
            {
                _playerDataSO.HasSetName();
                _playerDataSO.SetPlayerId(_playerDataSO.UserName);
                HideAll();
            }
            else
            {
                _playerDataSO.LoginErrorMessage = $"failed: {response.errorData}";
                HideWaitPanel();
            }
        });
    }

    public void ShowWaitPanel()
    {
        _loadingPanel.SetActive(true);
    }

    public void HideWaitPanel()
    {
        _loadingPanel.SetActive(false);
    }

    public void Show()
    {
        _loginPanel.SetActive(true);
        HideWaitPanel();
    }

    public void HideAll()
    {
        _loginPanel.SetActive(false);
        HideWaitPanel();
    }
}
