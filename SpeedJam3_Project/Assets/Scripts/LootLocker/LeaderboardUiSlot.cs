using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUiSlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _rankText = null;
    [SerializeField] TextMeshProUGUI _usernameText = null;
    [SerializeField] TextMeshProUGUI _scoreText = null;

    public void Setup(LootLockerLeaderboardMember _value, bool _isMe)
    {
        _rankText.text = $"#{_value.rank}";
        _usernameText.text = $"{_value.player.name}";
        _scoreText.text = $"{_value.score}";

        _rankText.color = _isMe ? Color.yellow : Color.white;
        _usernameText.color = _isMe ? Color.yellow : Color.white;
        _scoreText.color = _isMe ? Color.yellow : Color.white;
    }
}
