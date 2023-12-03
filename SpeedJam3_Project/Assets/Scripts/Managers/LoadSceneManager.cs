using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    [SerializeField, ReadOnly] bool _isLoading = false;

    public static event Action onStartLoading = null;
    public static event Action onFinishLoading = null;

    public void LoadScene(string _sceneName)
    {
        if (_isLoading) return;

        StartCoroutine(LoadScene_routine(_sceneName));
    }

    private IEnumerator LoadScene_routine(string _sceneName)
    {
        _isLoading = true;
        onStartLoading?.Invoke();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        _isLoading = false;
        onFinishLoading?.Invoke();
    }
}