using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    AudioSource _audioSource;// 音を鳴らすためのもの

    [SerializeField]
    [Header("効果音系")]
    SoundSFX[] _soundSFX;

    [SerializeField]
    [Header("BGM系")]
    SoundBGM[] _soundBGM;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayBGM(BGMType.Title);
    }

    /// <summary>BGMを変える関数</summary>
    /// <param name="type">シーンタイプ</param>
    public void PlayBGM(BGMType type)
    {
        _audioSource.Stop();
        var s = Array.Find(_soundBGM, x => x.Type == type);
        if (s != null)
        {
            _audioSource.clip = s.Clip;
            _audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioClipが無いです");
        }
    }

    /// <summary>効果音を鳴らすための関数</summary>
    /// <param name="type">効果音タイプ</param>
    public void PlaySFX(SFXType type)
    {
        var s = Array.Find(_soundSFX, x => x.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClipがないです");
        }
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    public void StopBGM()
    {
        _audioSource.Stop();
    }

    /// <summary>
    /// BGMを一時停止
    /// </summary>
    public void Pause()
    {
        _audioSource.Pause();
    }

    /// <summary>
    /// BGMを再開
    /// </summary>
    public void Restart()
    {
        _audioSource.UnPause();
    }

    [Serializable]
    public class SoundSFX
    {
        public AudioClip Clip => _clip;

        public SFXType Type => _type;

        [SerializeField]
        SFXType _type;

        [SerializeField]
        AudioClip _clip;
    }

    [Serializable]
    public class SoundBGM
    {
        public AudioClip Clip => _clip;

        public BGMType Type => _type;

        [SerializeField]
        BGMType _type;

        [SerializeField]
        AudioClip _clip;
    }
}