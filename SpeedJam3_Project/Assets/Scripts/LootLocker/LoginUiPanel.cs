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
    [SerializeField] TextMeshProUGUI _errorMessage = null;

    private IEnumerator Start()
    {
        //while (!_playerDataSO.HasLoggedIn)
        while (!LootLockerSDKManager.CheckInitialized())
        {
            yield return null;
        }

        if (PlayerPrefs.GetInt("HasSetName", 0) == 0)
        {
            Show();
        }
        else
        {
            HideAll();
        }
    }

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
        _errorMessage.text = _playerDataSO.LoginErrorMessage;
    }

    public void SetPlayerName()
    {
        _playerDataSO.UserName = _inputField.text;
        ShowWaitPanel();

        LootLockerSDKManager.SetPlayerName(_playerDataSO.UserName.ToString(), (response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerId", _playerDataSO.UserName);
                PlayerPrefs.SetInt("HasSetName", 1);
                HideAll();
            }
            else
            {
                _playerDataSO.LoginErrorMessage = $"failed: {response.errorData}";
                HideWaitPanel();
            }
        });

        //FindObjectOfType<LootLockerWhiteLoginManager>().TryCreateAccount();
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
