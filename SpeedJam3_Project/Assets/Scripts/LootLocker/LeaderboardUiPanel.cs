using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUiPanel : MonoBehaviour
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] string _leaderboardId = "18975";
    [Space]
    [SerializeField] GameObject _leaderboardPanel = null;
    [SerializeField] LeaderboardUiSlot _slotPrefab = null;
    [SerializeField] Transform _slotParent = null;
    //[SerializeField] Button _continueButton = null;
    [SerializeField] TextMeshProUGUI _loadingText = null;
    [SerializeField] List<LeaderboardUiSlot> _slots = null;

    [ContextMenu("Show()")]
    public void Show()
    {
        int _count = _slots.Count;

        for (int i = _count - 1; i >= 0; i--)
        {
            Destroy(_slots[i].gameObject);
        }

        _slots.Clear();

        _leaderboardPanel.SetActive(true);
        _loadingText.enabled = true;
        _loadingText.text = "Loading...";

        // Definir o score em outro lugar.
        _playerDataSO.Score = Random.Range(123, 456);

        SubmitScore();
    }

    public void Hide()
    {
        _leaderboardPanel.SetActive(false);
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(_playerDataSO.UserName, _playerDataSO.Score, _leaderboardId, (response) =>
        {
            if (response.statusCode == 200)
            {
                RetrieveLeaderboard();
                Debug.Log("Successful");
            }
            else
            {
                _loadingText.enabled = true;
                _loadingText.text = "failed: " + response.errorData;
                Debug.Log("failed: " + response.errorData);
            }
        });
    }

    private void RetrieveLeaderboard()
    {
        int count = 50;

        LootLockerSDKManager.GetScoreList(_leaderboardId, count, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                SetSlots(response);
                _loadingText.enabled = false;
                Debug.Log("Successful");
            }
            else
            {
                _loadingText.enabled = true;
                _loadingText.text = "failed: " + response.errorData;
                Debug.Log("failed: " + response.errorData);
            }
        });
    }

    private void SetSlots(LootLockerGetScoreListResponse _response)
    {
        int _count = _response.items.Length;

        for (int i = 0; i < _count; i++)
        {
            LeaderboardUiSlot _slot = Instantiate(_slotPrefab, _slotParent);
            _slot.gameObject.SetActive(true);
            _slots.Add(_slot);

            LootLockerLeaderboardMember _member = _response.items[i];
            bool _isMe = _member.member_id == _playerDataSO.UserName;
            _slot.Setup(_member, _isMe);
        }
    }
}
