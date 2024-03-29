using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] string _userName = null;
    [SerializeField] string _loginErrorMessage = null;
    [SerializeField] string _leaderboardId = "18975";
    [SerializeField] int _score = 0;
    [SerializeField] bool _canCountTime = false;

    public const string KEY_PLAYER_ID = "PlayerId";
    public const string KEY_HAS_SET_NAME = "HasSetName";

    public string UserName { get => _userName; set => _userName = value; }
    public string LoginErrorMessage { get => _loginErrorMessage; set => _loginErrorMessage = value; }
    public int Score { get => _score; set => _score = value; }
    public bool CanCountTime { get => _canCountTime; set => _canCountTime = value; }
    public string LeaderboardId { get => _leaderboardId; private set => _leaderboardId = value; }

    private void OnEnable()
    {
        _userName = null;
        _loginErrorMessage = null;
        _score = 0;
        _canCountTime = false;
    }

    public void SetPlayerId(string _value)
    {
        _userName = _value;
        PlayerPrefs.SetString(KEY_PLAYER_ID, _userName);
    }

    public void LoadPlayerId()
    {
        _userName = PlayerPrefs.GetString(KEY_PLAYER_ID, null);
    }

    public void SetPlayerName()
    {
        PlayerPrefs.SetInt(KEY_HAS_SET_NAME, 1);
    }

    public bool HasSetName()
    {
        return PlayerPrefs.GetInt(KEY_HAS_SET_NAME, 0) == 1;
    }
}
