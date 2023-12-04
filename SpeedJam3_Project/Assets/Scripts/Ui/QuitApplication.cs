using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
    [SerializeField] Button _button = null;

    private void OnEnable()
    {
        _button.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Quit()
    {
        Application.Quit();
    }
}
