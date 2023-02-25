using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Canvas BattleCanvas => _battleCanvas;

    public Text LogText => _logText;

    const float MOVE_Y = 50f;// どのくらい上に動くか

    const float MOVE_TIME = 0.8f;// 何秒で上に行くか

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

    [SerializeField]
    [Header("選択ページ1")]
    private GameObject _page_1;

    [SerializeField]
    [Header("選択ページ2")]
    private GameObject _page_2;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _logText;

    [SerializeField]
    [Header("詳細説明ボタン")]
    private Button _detailButton;

    private Vector3 _enemyTextPosition = new Vector3(-113f, -65f, 0f);// 固定値

    private Vector3 _playerTextPosition = new Vector3(100f, -34f, 0f);// 固定値

    private bool _isOpen;

    private void Start()
    {
        _enemyDamageText.text = null;   
        _playerDamageText.text = null;
        _logText.text = null;
        _battleCanvas.gameObject.SetActive(false);
        _charaCanvas.gameObject.SetActive(true);
    }

    public void EnemyDamageTextPopUp(float value)
    {
        FadeInOutText(_enemyText, _enemyDamageText, value, _enemyTextPosition);
    }

    public void PlayerDamageTextPopUp(float value)
    {
        FadeInOutText(_playerText, _playerDamageText, value, _playerTextPosition);
    }

    /// <summary>
    /// 選択画面を切り替えるための関数
    /// </summary>
    public void ActionPageChange()
    {
        if (_page_1.activeSelf)
        {
            _page_1.gameObject.SetActive(false);
            _page_2.gameObject.SetActive(true);
        }
        else
        {
            _page_1.gameObject.SetActive(true);
            _page_2.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// テキストをポップアップさせたり
    /// 表示非表示を切り替えるための関数
    /// </summary>
    private void FadeInOutText(CanvasGroup canvasGroup, Text damageText, float value, Vector3 vector3)
    {
        canvasGroup.alpha = 1f;// 初期値に戻す

        damageText.transform.localPosition = vector3;
        damageText.text = value.ToString();

        DOTween.Sequence()
            .Append(damageText.transform.DOLocalMoveY(MOVE_Y, MOVE_TIME))
            .Join(CanvasGroupExtensions.FadeOut(canvasGroup, MOVE_TIME));
    }

    /// <summary>
    /// キャンバスを非表示にする関数
    /// </summary>
    public void CanvasFalse()
    {
        _battleCanvas.gameObject.SetActive(false);
        GameManager.Instance.ChangeGameMode(true);
    }


    /// <summary>
    /// アクションコマンドの説明イメージ
    /// を開いたり閉じたりする関数
    /// </summary>
    public void DetailExplanationButton(Image image)
    {
        if (!_isOpen)
        {
            image.transform.DOScale(1f, 2f);
            _isOpen = true;
        }
        else if (_isOpen)
        {
            image.transform.DOScale(0f, 2f);
            _isOpen = false;
        }
    }
}
