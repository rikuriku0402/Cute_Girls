using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    [Header("�ҋ@����")]
    private float _fadeTime;

    [SerializeField]
    [Header("�t�F�[�h�C���[�W")]
    private CanvasGroup _fadeImage;

    [SerializeField]
    [Header("�T�E���h�}�l�[�W���[")]
    private SoundManager _soundManager;

    private void Start()
    {
        FadeOut();
    }

    public void FadeOut()
    {
        CanvasGroupExtensions.FadeOut(_fadeImage, _fadeTime);
    }

    public void FadeIn()
    {
        CanvasGroupExtensions.FadeIn(_fadeImage, _fadeTime);
    }

    public void FadeInSceneChange(string scene)
    {
        _soundManager.PlaySFX(SFXType.SceneChange);
        CanvasGroupExtensions.FadeInSceneChange(_fadeImage, _fadeTime, scene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
