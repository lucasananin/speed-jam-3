using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Space]
    [SerializeField] AudioSource _musicAudio = null;
    [SerializeField] AudioSource _sfxAudio = null;
    [Space]
    [SerializeField] AudioClip _sfxClip = null;

    public void PlayMusic()
    {
        if (!_musicAudio.isPlaying)
        {
            _musicAudio.Play();
        }
    }

    public void StopMusic()
    {
        _musicAudio.Stop();
    }

    public void PlaySfx()
    {
        _sfxAudio.Play();
    }

    public void StopSfx()
    {
        _sfxAudio.Stop();
    }

    public void PlayScoreSfx()
    {
        _sfxAudio.PlayOneShot(_sfxClip);
    }
}
