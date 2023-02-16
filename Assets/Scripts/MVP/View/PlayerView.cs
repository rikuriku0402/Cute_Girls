using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("ボタンリスト")]
    private List<Button> _buttons = new();

    [SerializeField]
    [Header("体力スライダー")]
    private Slider _hpSlider;

    [SerializeField]
    [Header("MPスライダー")]
    private Slider _mpSlider;

    [SerializeField]
    [Header("攻撃ボタン")]
    private Button _attackButton;

    [SerializeField]
    [Header("防御ボタン")]
    private Button _defenceButton;

    [SerializeField]
    [Header("ポーション攻撃ボタン")]
    private Button _portionAttackButton;

    [SerializeField]
    [Header("ポーション回復ボタン")]
    private Button _portionRecoveryButton;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _logText;

    [SerializeField]
    [Header("バトルシステムクラス")]
    private BattleManager _battleSystem;

    #endregion

    #region Unity Method

    private void Start()
    {
        _attackButton.onClick.AddListener(() => Attack());
        _defenceButton.onClick.AddListener(() => Defence());
        _portionAttackButton.onClick.AddListener(() => PortionAttack());
        _portionRecoveryButton.onClick.AddListener(() => MPRecovery());
    }

    #endregion

    #region Method

    public void SetHP(int hpCount) => _hpSlider.value = hpCount;

    public void SetMP(int mpCount) => _mpSlider.value = mpCount;

    #endregion

    #region Button Method

    /// <summary>
    /// アタックボタンに登録する関数
    /// </summary>
    private async void Attack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Playerが敵に" + _battleSystem.PlayerAttack + "与えた";
        await _battleSystem.Attack();
        _logText.text = "敵がPlayerに" + _battleSystem.EnemyAttack + "与えた";
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// 防御ボタンに登録する関数
    /// </summary>
    private async void Defence()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "防御した" + _battleSystem.EnemyAttack + "くらった";
        await _battleSystem.Defence();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// ポーションボタンに登録する関数
    /// </summary>
    private async void PortionAttack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Playerが敵に" + _battleSystem.PortionAttack + "与えた";
        await _battleSystem.Portion();
        _logText.text = "敵がPlayerに" + _battleSystem.EnemyAttack + "与えた";
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// MP回復ボタンに登録する関数
    /// </summary>
    private async void MPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "MPを" + _battleSystem.MPPortionRecovery + "回復した";
        await _battleSystem.MPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
