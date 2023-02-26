using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    [Header("���ʉ��n")]
    private SoundSFX[] _soundSFX;

    [SerializeField]
    [Header("BGM�n")]
    private SoundBGM[] _soundBGM;

    private AudioSource _audioSource;// ����炷���߂̂���

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        FirstBGM();
    }

    /// <summary>BGM��ς���֐�</summary>
    /// <param name="type">�V�[���^�C�v</param>
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
            Debug.LogError("AudioClip�������ł�");
        }
    }

    /// <summary>���ʉ���炷���߂̊֐�</summary>
    /// <param name="type">���ʉ��^�C�v</param>
    public void PlaySFX(SFXType type)
    {
        var s = Array.Find(_soundSFX, x => x.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClip���Ȃ��ł�");
        }
    }

    /// <summary>
    /// BGM���~�߂�
    /// </summary>
    public void StopBGM()
    {
        _audioSource.Stop();
    }

    /// <summary>
    /// BGM���ꎞ��~
    /// </summary>
    public void Pause()
    {
        _audioSource.Pause();
    }

    /// <summary>
    /// BGM���ĊJ
    /// </summary>
    public void Restart()
    {
        _audioSource.UnPause();
    }

    private void FirstBGM()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                PlayBGM(BGMType.Title);
                break;

            case "Game":
                PlayBGM(BGMType.Game);
                break;

            case "GameClear":
                PlayBGM(BGMType.GameClear);
                break;

            case "GameOver":
                PlayBGM(BGMType.GameOver);
                break;
        }
    }

    [Serializable]
    private class SoundSFX
    {
        public AudioClip Clip => _clip;

        public SFXType Type => _type;

        [SerializeField]
        SFXType _type;

        [SerializeField]
        AudioClip _clip;
    }

    [Serializable]
    private class SoundBGM
    {
        public AudioClip Clip => _clip;

        public BGMType Type => _type;

        [SerializeField]
        BGMType _type;

        [SerializeField]
        AudioClip _clip;
    }
}