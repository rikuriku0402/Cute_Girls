using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("Button List")]
    List<Button> _buttons = new();

    [SerializeField]
    [Header("HP Slider")]
    Slider _hpSlider;

    [SerializeField]
    [Header("MP Slider")]
    Slider _mpSlider;

    [SerializeField]
    [Header("Attack Button")]
    Button _attackButton;

    [SerializeField]
    [Header("Defence Button")]
    Button _defenceButton;

    [SerializeField]
    [Header("Portion Attack Button")]
    Button _portionAttackButton;

    [SerializeField]
    [Header("Portion Recovery Button")]
    Button _portionRecoveryButton;

    [SerializeField]
    [Header("Log Text")]
    Text _logText;

    [SerializeField]
    [Header("Battle System")]
    BattleManager _battleSystem;

    #endregion

    #region Unity Method

    private void Start()
    {
        // リストでボタンごとに関数を登録したい

        //_attackButton.onClick.AddListener(() => Attack());
        // これでVoidでも呼び出せる


        _attackButton.onClick.AddListener(Attack);
        _defenceButton.onClick.AddListener(Defence);
        _portionAttackButton.onClick.AddListener(PortionAttack);
        _portionRecoveryButton.onClick.AddListener(MPRecovery);
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
    async void Attack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Playerが敵に" + _battleSystem.PlayerAttack + "与えた";
        await _battleSystem.Attack();
        _logText.text = "敵がPlayerに" + _battleSystem.EnemyAttack + "与えた";
        _buttons.ForEach(x => x.interactable = true);

        #region これは避けたい
        // しょうがなくListで管理している
        //_attackButton.interactable = false;
        //_defenceButton.interactable = false;
        //_portionAttackButton.interactable = false;
        //_portionRecoveryButton.interactable = false;
        #endregion
    }

    /// <summary>
    /// 防御ボタンに登録する関数
    /// </summary>
    async void Defence()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "防御した" + _battleSystem.EnemyAttack + "くらった";
        await _battleSystem.Defence();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// ポーションボタンに登録する関数
    /// </summary>
    async void PortionAttack()
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
    async void MPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "MPを" + _battleSystem.MPPortionRecovery + "回復した";
        await _battleSystem.MPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
