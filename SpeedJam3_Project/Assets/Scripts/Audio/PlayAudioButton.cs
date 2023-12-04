using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioButton : MonoBehaviour
{
    [SerializeField] Button _button = null;

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySfx);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySfx);
    }

    private void PlaySfx()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonSfx();
        }
    }
}
