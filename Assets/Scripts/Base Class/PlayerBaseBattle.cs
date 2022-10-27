using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PlayerBaseBattle : MonoBehaviour
{
    ActionEnum _type;


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
    [Header("�G�̍U����")]
    int _enemyAttack;

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(x => LifeCheck());
    }

    void LifeCheck()
    {
        if (_playerData.Life.Value <= 0)
        {
            GameManager.GameOver();
        }
        if (_enemyData.Life.Value <= 0)
        {
            GameManager.GameClear();
        }
    }

    public void Attack()
    {
        //�{�^����Active��������
        _enemyData.Damage(_playerAttack);
        print("�v���C���[���G��" + _playerAttack + "�^����");
        //�{�^�����Active
        _buttons.ForEach(x => x.interactable = false);
        _type = ActionEnum.Attack;
        StartCoroutine(WaitTime());
    }

    public void Defance()
    {
        _buttons.ForEach(x => x.interactable = false);
        _type = ActionEnum.Defense;
        StartCoroutine(WaitTime());
    }


    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(2f);
        switch (_type)
        {
            case ActionEnum.Attack:
                _playerData.Damage(_enemyAttack);
                print("�G���v���C���[��" + _enemyAttack + "�^����");
                _buttons.ForEach(x => x.interactable = true);
        //�{�^����Active
                break;
            case ActionEnum.Defense:
                int allAttack = _enemyAttack - _defence;
                _playerData.Damage(allAttack);
                print("�G���v���C���[��" + allAttack + "�^����");
                _buttons.ForEach(x => x.interactable = true);
                break;
        }
    }
}
