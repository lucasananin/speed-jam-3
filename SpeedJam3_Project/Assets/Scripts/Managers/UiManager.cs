using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] GameObject _loadingPanel = null;

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

    private void ShowLoadingPanel()
    {
        _loadingPanel.gameObject.SetActive(true);
    }

    private void HideLoadingPanel()
    {
        _loadingPanel.gameObject.SetActive(false);
    }
}
