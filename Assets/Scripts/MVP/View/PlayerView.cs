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
    [Header("ポーション回復ボタン")]
    private Button _hpRecoveryButton;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _logText;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _hpText;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _mpText;

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
        _hpRecoveryButton.onClick.AddListener(() => HPRecovery());
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
            _mpText.text = 0 + "/" + _mpSlider.maxValue;
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

    /// <summary>
    /// HP回復ボタンに登録する関数
    /// </summary>
    private async void HPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "HPを" + _battleSystem.HPPoritonRecovery + "回復した";
        await _battleSystem.HPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
