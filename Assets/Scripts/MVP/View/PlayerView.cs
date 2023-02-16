using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("�{�^�����X�g")]
    private List<Button> _buttons = new();

    [SerializeField]
    [Header("�̗̓X���C�_�[")]
    private Slider _hpSlider;

    [SerializeField]
    [Header("MP�X���C�_�[")]
    private Slider _mpSlider;

    [SerializeField]
    [Header("�U���{�^��")]
    private Button _attackButton;

    [SerializeField]
    [Header("�h��{�^��")]
    private Button _defenceButton;

    [SerializeField]
    [Header("�|�[�V�����U���{�^��")]
    private Button _portionAttackButton;

    [SerializeField]
    [Header("�|�[�V�����񕜃{�^��")]
    private Button _portionRecoveryButton;

    [SerializeField]
    [Header("���O�e�L�X�g")]
    private Text _logText;

    [SerializeField]
    [Header("�o�g���V�X�e���N���X")]
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
    /// �A�^�b�N�{�^���ɓo�^����֐�
    /// </summary>
    private async void Attack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Player���G��" + _battleSystem.PlayerAttack + "�^����";
        await _battleSystem.Attack();
        _logText.text = "�G��Player��" + _battleSystem.EnemyAttack + "�^����";
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// �h��{�^���ɓo�^����֐�
    /// </summary>
    private async void Defence()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "�h�䂵��" + _battleSystem.EnemyAttack + "�������";
        await _battleSystem.Defence();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// �|�[�V�����{�^���ɓo�^����֐�
    /// </summary>
    private async void PortionAttack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Player���G��" + _battleSystem.PortionAttack + "�^����";
        await _battleSystem.Portion();
        _logText.text = "�G��Player��" + _battleSystem.EnemyAttack + "�^����";
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// MP�񕜃{�^���ɓo�^����֐�
    /// </summary>
    private async void MPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "MP��" + _battleSystem.MPPortionRecovery + "�񕜂���";
        await _battleSystem.MPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
