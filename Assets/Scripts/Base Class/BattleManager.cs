using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class BattleManager : MonoBehaviour
{
    bool _isPortion;

    ActionType _actionType;

    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�G�l�~�[�f�[�^")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("�{�^�����X�g")]
    List<Button> _buttons = new();

    [SerializeField]
    [Header("�f�B�t�F���X")]
    int _defence;

    [SerializeField]
    [Header("�v���C���[�̍U����")]
    int _playerAttack;

    [SerializeField]
    [Header("�|�[�V�����̍U����")]
    int _portionAttack;

    [SerializeField]
    [Header("�g�pMP")]
    int _portionMp;

    [SerializeField]
    [Header("�G�̍U����")]
    int _enemyAttack;

    [SerializeField]
    [Header("���O�e�L�X�g")]
    Text _logText;

    private void Start()
    {
        _isPortion = true;
        this.UpdateAsObservable().Subscribe(x => LifeCheck());
    }

    void LifeCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            GameManager.GameOver();
        }
        if (_enemyData.Hp.Value <= 0)
        {
            GameManager.GameClear();
        }
    }

    void MPCheck()
    {
        if (_portionMp <= 0)
        {
            _isPortion = false;
        }
    }

    public void Attack()
    {
        //�{�^����Active��������
        _enemyData.HpDamage(_playerAttack);
        print("�v���C���[���G��" + _playerAttack + "�^����");
        // �e�L�X�g�Ƀ_���[�W�ʂƂ����o��
        _logText.text = "�v���C���[���G��" + _playerAttack + "�^����";
        //�{�^�����Active
        _buttons.ForEach(x => x.interactable = false);
        _actionType = ActionType.Attack;
        StartCoroutine(WaitTime());
    }

    public void Defance()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "�h�䂷��";
        _actionType = ActionType.Defense;
        StartCoroutine(WaitTime());
    }

    public void Portion()
    {
        if (_isPortion)
        {
            _enemyData.HpDamage(_portionAttack);
            _playerData.MpDamage(_portionMp);
            print("�v���C���[���G��" + _portionAttack + "�^����");
            _logText.text = "�v���C���[���G��" + _portionAttack + "�^����";
            _buttons.ForEach(x => x.interactable = false);
            _actionType = ActionType.Portion;
            StartCoroutine(WaitTime());
            MPCheck();
        }
        else
        {
            _logText.text = "MP������Ȃ���";
        }
    }

    /// <summary>
    /// �A�Ŗh�~
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        _logText.text = null;
        int allAttack = 0;

        switch (_actionType)
        {
            case ActionType.Attack:
                _playerData.HpDamage(_enemyAttack);
                print("�G���v���C���[��" + _enemyAttack + "�^����");
                //�{�^����Active
                break;

            case ActionType.Defense:
                allAttack = _enemyAttack - _defence;
                _playerData.HpDamage(allAttack);
                print("�G���v���C���[��" + allAttack + "�^����");
                break;

            case ActionType.Portion:
                allAttack = _enemyAttack + _enemyAttack;
                _playerData.HpDamage(allAttack);
                print("�G���v���C���[��" + allAttack + "�^����");
                break;

            case ActionType.Recovery:
                // MP�񕜃X�L��
                break;

            case ActionType.HpRecvery:
                // HP�񕜃X�L��
                break;
        }
        _buttons.ForEach(x => x.interactable = true);
    }
}
