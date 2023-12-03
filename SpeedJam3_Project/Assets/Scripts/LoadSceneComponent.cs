using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneComponent : MonoBehaviour
{
    [SerializeField] string _sceneName = null;

    public void LoadScene()
    {
        if (LoadSceneManager.Instance == null) return;

        LoadSceneManager.Instance.LoadScene(_sceneName);
    }
}
