using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Space]
    [SerializeField] AudioSource _musicAudio = null;
    [SerializeField] AudioSource _shootSfxAudio = null;
    [Space]
    [SerializeField] AudioClip _shootSfxClip = null;

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

    public void PlayShootSfx()
    {
        _shootSfxAudio.pitch = Random.Range(1, 1.2f);
        _shootSfxAudio.PlayOneShot(_shootSfxClip);
    }

    public void PlaySfx()
    {
        _shootSfxAudio.Play();
    }

    public void StopSfx()
    {
        _shootSfxAudio.Stop();
    }
}
