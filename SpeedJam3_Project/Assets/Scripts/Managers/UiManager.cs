using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] GameObject _loadingPanel = null;
    [SerializeField] TextMeshProUGUI _timeScoreText = null;

    private void Awake()
    {
        HideLoadingPanel();
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
}
