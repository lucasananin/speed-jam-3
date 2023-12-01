using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSubmitter : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] string _leaderboardId = "18975";
    [SerializeField] string _memberID = "lucasananin";
    [SerializeField] int _score = 123;

    private LootLockerSubmitScoreResponse _submiteResponse = null;
    private LootLockerGetScoreListResponse _retrieveResponse = null;

    [ContextMenu("SubmitScore()")]
    public void SubmitScore()
    {
        //var _manager = GetComponent<LootLockerManager>();
        //var _data = _manager.GetGuestData();
        //_data.player_identifier = _memberID;

        //var _memberID = PlayerPrefs.GetString("PlayerId", null);

        //LootLockerSDKManager.SubmitScore(_memberID, _score, _leaderboardId, (response) =>
        LootLockerSDKManager.SubmitScore(_playerDataSO.UserName, _playerDataSO.Score, _leaderboardId, (response) =>
        {
            if (response.statusCode == 200)
            {
                //_submiteResponse = response;
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.errorData);
            }
        });
    }

    [ContextMenu("RetrieveScore()")]
    public void RetrieveScore()
    {
        int count = 50;

        LootLockerSDKManager.GetScoreList(_leaderboardId, count, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                //_retrieveResponse = response;
                //_playerDataSO.RetrieveResponse = response;
                Debug.Log("Successful");
            }
            else
            {
                //_playerDataSO.RetrieveResponse = null;
                Debug.Log("failed: " + response.errorData);
            }
        });
    }
}
