using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Canvas BattleCanvas => _battleCanvas;

    const float MOVE_Y = 50f;

    const float WAIT_TIME = 0.8f;

    [SerializeField]
    [Header("バトルキャンバス")]
    private Canvas _battleCanvas;

    [SerializeField]
    [Header("キャラ選択キャンバス")]
    private Canvas _charaCanvas;

    [SerializeField]
    [Header("敵のダメージテキスト")]
    private Text _enemyDamageText;

    [SerializeField]
    [Header("敵のダメージテキスト")]
    private CanvasGroup _enemyText;

    [SerializeField]
    [Header("プレイヤーのダメージテキスト")]
    private Text _playerDamageText;

    [SerializeField]
    [Header("プレイヤーのダメージテキスト")]
    private CanvasGroup _playerText;

    private Vector3 _enemyTextPosition = new Vector3(-113f, -65f, 0f);

    private Vector3 _playerTextPosition = new Vector3(100f, -34f, 0f);

    private void Start()
    {
        _enemyDamageText.text = null;   
        _playerDamageText.text = null;   
        _battleCanvas.gameObject.SetActive(false);
        _charaCanvas.gameObject.SetActive(true);
    }

    public void EnemyDamageTextPopUp(float value)
    {
        _enemyText.alpha = 1f;// 初期値に戻す

        _enemyDamageText.transform.localPosition = _enemyTextPosition;
        _enemyDamageText.text = value.ToString();

        DOTween.Sequence()
            .Append(_enemyDamageText.transform.DOLocalMoveY(MOVE_Y, WAIT_TIME))
            .Join(CanvasGroupExtensions.FadeOut(_enemyText, WAIT_TIME));
    }

    public void PlayerDamageTextPopUp(float value)
    {
        _playerText.alpha = 1f;// 初期値に戻す

        _playerDamageText.transform.localPosition = _playerTextPosition;
        _playerDamageText.text = value.ToString();

        DOTween.Sequence()
            .Append(_playerDamageText.transform.DOLocalMoveY(MOVE_Y, WAIT_TIME))
            .Join(CanvasGroupExtensions.FadeOut(_playerText, WAIT_TIME));
    }
}
