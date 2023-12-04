using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] PlayerDataSO _playerDataSO = null;
    [SerializeField] GameObject _loadingPanel = null;
    [SerializeField] TextMeshProUGUI _timeScoreText = null;

    private void Awake()
    {
        HideLoadingPanel();
        HideTimePanel();
    }

    private void OnEnable()
    {
        LoadSceneManager.onStartLoading += ShowLoadingPanel;
        LoadSceneManager.onFinishLoading += HideLoadingPanel;
    }

    private void OnDisable()
    {
        LoadSceneManager.onStartLoading -= ShowLoadingPanel;
        LoadSceneManager.onFinishLoading -= HideLoadingPanel;
    }

    private void Update()
    {
        _timeScoreText.enabled = _playerDataSO.CanCountTime;
        _timeScoreText.text = TimeManager.Instance.GetTimeString();
    }

    private void ShowLoadingPanel()
    {
        _loadingPanel.gameObject.SetActive(true);
    }

    private void HideLoadingPanel()
    {
        _loadingPanel.gameObject.SetActive(false);
    }

    public void ShowTimePanel()
    {
        _timeScoreText.enabled = true;
    }

    public void HideTimePanel()
    {
        _timeScoreText.enabled = false;
    }
}
