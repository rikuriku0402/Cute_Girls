using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public static class CanvasGroupExtensions
{
    public static Tweener FadeOut(this CanvasGroup canvasGroup, float duration)
    {
        canvasGroup.alpha = 1f;
        return canvasGroup.DOFade(0.0f, duration);
    }

    public static Tweener FadeIn(this CanvasGroup canvasGroup, float duration)
    {
        canvasGroup.alpha = 0f;
        return canvasGroup.DOFade(1.0f, duration);
    }

    public static Tweener FadeInSceneChange(this CanvasGroup canvasGroup, float duration, string scene)
    {
        canvasGroup.alpha = 0f;
        return canvasGroup.DOFade(1.0f, duration)
            .OnComplete(() => SceneManager.LoadSceneAsync(scene));
    }
}
