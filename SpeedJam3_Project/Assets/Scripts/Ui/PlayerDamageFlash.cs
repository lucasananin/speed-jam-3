using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

public class PlayerDamageFlash : MonoBehaviour
{
    [SerializeField] Image _image = null;
    [SerializeField] float _defaultAlpha = 0.5f;
    [SerializeField] float _duration = 0.3f;

    private void Awake()
    {
        var _c = _image.color;
        _c.a = 0;
        _image.color = _c;
        //_image.DOFade(_defaultAlpha, 0);
    }

    private void OnEnable()
    {
        PlayerHealth.onPlayerTakeDamage += Play;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerTakeDamage -= Play;
    }

    [Button]
    private void Play()
    {
        _image.DOComplete();
        _image.DOFade(_defaultAlpha, 0);
        _image.DOFade(0, _duration);
    }
}
