using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Space]
    //[SerializeField] AudioSource _musicAudio = null;
    [SerializeField] AudioSource _shootSfxAudio = null;
    [SerializeField] AudioSource _buttonSfxAudio = null;
    [SerializeField] AudioSource _switchSfxAudio = null;
    [SerializeField] AudioSource _defeatSfxAudio = null;
    [SerializeField] AudioSource _crackedShieldSfxAudio = null;
    [SerializeField] AudioSource _levelFinishSfxAudio = null;
    [Space]
    [SerializeField] AudioClip _shootSfxClip = null;
    [SerializeField] AudioClip _buttonSfxClip = null;
    [SerializeField] AudioClip _switchSfxClip = null;
    [SerializeField] AudioClip _defeatSfxClip = null;
    [SerializeField] AudioClip _crackedShieldSfxClip = null;
    [SerializeField] AudioClip _levelFinishSfxClip = null;

    //public void PlayMusic()
    //{
    //    if (!_musicAudio.isPlaying)
    //    {
    //        _musicAudio.Play();
    //    }
    //}

    //public void StopMusic()
    //{
    //    _musicAudio.Stop();
    //}

    [Button]
    public void PlayShootSfx()
    {
        _shootSfxAudio.pitch = Random.Range(1f, 1.2f);
        _shootSfxAudio.PlayOneShot(_shootSfxClip);
    }

    [Button]
    public void PlayButtonSfx()
    {
        _buttonSfxAudio.PlayOneShot(_buttonSfxClip);
    }

    [Button]
    public void PlaySwitchSfx()
    {
        _switchSfxAudio.PlayOneShot(_switchSfxClip);
    }

    [Button]
    public void PlayDefeatSfx()
    {
        _defeatSfxAudio.PlayOneShot(_defeatSfxClip);
    }

    [Button]
    public void PlayCrackedShieldSfx()
    {
        _crackedShieldSfxAudio.PlayOneShot(_crackedShieldSfxClip);
    }

    [Button]
    public void PlayLevelFinishSfx()
    {
        _levelFinishSfxAudio.PlayOneShot(_levelFinishSfxClip);
    }
}
