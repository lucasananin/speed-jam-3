using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] string _userName = null;
    [SerializeField] string _loginErrorMessage = null;
    [SerializeField] int _score = 0;
    //[SerializeField] bool _hasLoggedIn = false;

    //private LootLockerGetScoreListResponse _retrieveResponse = null;

    public string UserName { get => _userName; set => _userName = value; }
    public string LoginErrorMessage { get => _loginErrorMessage; set => _loginErrorMessage = value; }
    public int Score { get => _score; set => _score = value; }
    //public bool HasLoggedIn { get => _hasLoggedIn; set => _hasLoggedIn = value; }
    //public LootLockerGetScoreListResponse RetrieveResponse { get => _retrieveResponse; set => _retrieveResponse = value; }
}
