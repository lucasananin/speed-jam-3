using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootLockerWhiteLoginManager : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] LoginUiPanel _loginPanel = null;
    //[SerializeField] string _email = "user@lootlocker.io";

    private string PASSWORD = "myLittlePassword";

    // ao comecar o jogo, insere o usuario.
    // se existir, faz login.
    // se nao existir, cria e depois faz login.

    public void TryCreateAccount()
    {
        LootLockerSDKManager.WhiteLabelSignUp(_playerDataSO.UserName, PASSWORD, (response) =>
        {
            if (!response.success)
            {
                if (response.statusCode == 400)
                {
                    // Usuário já existe, fazendo login...
                    WhiteLabelLoginAndStartSession(_playerDataSO.UserName);
                    return;
                }

                HideWaitPanel("error while creating user");
                Debug.Log("error while creating user");
                return;
            }

            // Usuário não existe, criando conta...
            CreateNewWhiteLabelUser(_playerDataSO.UserName);
            Debug.Log("user created successfully");
        });

        //WhiteLabelLoginAndStartSession(_playerDataSO.UserName);
    }

    //[ContextMenu("CreateNewWhiteLabelUser()")]
    //public void CreateNewWhiteLabelUser()
    //{
    //    CreateNewWhiteLabelUser(_email);
    //}

    //[ContextMenu("WhiteLabelLoginAndStartSession()")]
    //private void WhiteLabelLoginAndStartSession()
    //{
    //    WhiteLabelLoginAndStartSession(_email);
    //}

    public void WhiteLabelLoginAndStartSession(string _userName)
    {
        // This code should be placed in a handler when user clicks the login button.
        //string email = "user@lootlocker.io";
        //string password = "myLittlePassword";
        bool rememberMe = true;

        LootLockerSDKManager.WhiteLabelLoginAndStartSession(_userName, PASSWORD, rememberMe, response =>
        {
            if (!response.success)
            {
                if (!response.LoginResponse.success)
                {
                    HideWaitPanel("error while logging in");
                    Debug.Log("error while logging in");
                }
                else if (!response.SessionResponse.success)
                {
                    HideWaitPanel("error while starting session");
                    Debug.Log("error while starting session");
                }
                return;
            }

            HideLoginPanel();
        });
    }

    public void CreateNewWhiteLabelUser(string _userName)
    {
        // This code should be placed in a handler when user clicks the sign up button.
        //string email = "user@lootlocker.io";
        //string password = "myLittlePassword";

        LootLockerSDKManager.WhiteLabelSignUp(_userName, PASSWORD, (response) =>
        {
            if (!response.success)
            {
                HideWaitPanel("error while creating user");
                Debug.Log("error while creating user");
                return;
            }

            WhiteLabelLoginAndStartSession(_playerDataSO.UserName);
            Debug.Log("user created successfully");
        });
    }

    private void HideWaitPanel(string _errorMessage)
    {
        _loginPanel.HideWaitPanel();
        _playerDataSO.LoginErrorMessage = _errorMessage;
    }

    private void HideLoginPanel()
    {
        _loginPanel.HideAll();
        _playerDataSO.LoginErrorMessage = null;
    }
}
