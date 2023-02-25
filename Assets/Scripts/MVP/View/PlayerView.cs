using System;
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
    [Header("魔法攻撃ボタン")]
    private Button _magicAttackButton;

    [SerializeField]
    [Header("魔法回復ボタン")]
    private Button _magicRecoveryButton;

    [SerializeField]
    [Header("ポーション回復ボタン")]
    private Button _hpRecoveryButton;

    [SerializeField]
    [Header("必殺技ボタン")]
    private Button _deathblowButton;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _hpText;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _mpText;

    [SerializeField]
    [Header("BattleManager")]
    private BattleManager _battleSystem;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    #endregion

    #region Unity Method

    private void Start()
    {
        _attackButton.onClick.AddListener(() => Attack());
        _defenceButton.onClick.AddListener(() => Defence());
        _magicAttackButton.onClick.AddListener(() => MagicAttack());
        _magicRecoveryButton.onClick.AddListener(() => MPRecovery());
        _hpRecoveryButton.onClick.AddListener(() => HPRecovery());
        _deathblowButton.onClick.AddListener(() => Deathblow());
    }


    #endregion

    #region Method

    public void SetHP(int hp)
    {
        _hpSlider.value = hp;
        _hpText.text = hp.ToString() + "/" + _hpSlider.maxValue;
        if (hp <= 0)
        {
            _hpText.text = 0 + "/" + _hpSlider.maxValue;
        }
    }

    public void SetMP(int mp)
    {
        _mpSlider.value = mp;
        _mpText.text = mp.ToString() + "/" + _mpSlider.maxValue;
        if (mp <= 0)
        {
            mp = 0;
            _mpText.text = mp + "/" + _mpSlider.maxValue;
        }
    }

    #endregion

    #region Button Method

    /// <summary>
    /// アタックボタンに登録する関数
    /// </summary>
    private async void Attack()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.Attack();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// 防御ボタンに登録する関数
    /// </summary>
    private async void Defence()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.Defence();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// ポーションボタンに登録する関数
    /// </summary>
    private async void MagicAttack()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.Magic();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// MP回復ボタンに登録する関数
    /// </summary>
    private async void MPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.MPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// HP回復ボタンに登録する関数
    /// </summary>
    private async void HPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.HPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// 必殺技ボタンに登録する関数
    /// </summary>
    private async void Deathblow()
    {
        _buttons.ForEach(x => x.interactable = false);
        await _battleSystem.Deathblow();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
