using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class BattleManager : MonoBehaviour
{
    #region Property

    public int PlayerAttack => _playerAttack;

    public int EnemyAttack => _enemyAttack;

    public int PortionAttack => _portionAttack;

    public int MPPortionRecovery => _mPRecovery;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("Player Data")]
    PlayerData _playerData;

    [SerializeField]
    [Header("Enemy Data")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("Defence")]
    int _defence;

    [SerializeField]
    [Header("Player Attack")]
    int _playerAttack;

    [SerializeField]
    [Header("Portion Attack")]
    int _portionAttack;

    [SerializeField]
    [Header("MP Recovery")]
    int _mPRecovery;

    [SerializeField]
    [Header("Use MP")]
    int _portionMp;

    [SerializeField]
    [Header("Enemy Attack")]
    int _enemyAttack;

    [SerializeField]
    [Header("Enemy Canvas")]
    GameObject _enemyCanvasPanel;

    #endregion

    #region Method

    /// <summary>
    /// �U������֐�
    /// </summary>
    public async UniTask Attack()
    {
        print("�G�ɍU��");
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(_enemyAttack);
        HpCheck();
    }

    /// <summary>
    /// �h�䂷��֐�
    /// </summary>
    public async UniTask Defence()
    {
        MPCheck();
        int allAttack = _enemyAttack - 10;// �}�W�b�N�i���o�[
        _playerData.MpDamage(_portionMp);
        print("�h��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// �|�[�V�����ōU������֐�
    /// </summary>
    public async UniTask Portion()
    {
        MPCheck();
        _enemyData.Damage(_portionAttack);
        _playerData.MpDamage(_portionMp);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(_enemyAttack);
        HpCheck();
    }

    /// <summary>
    /// �|�[�V�������񕜂���֐�
    /// </summary>
    public async UniTask MPRecovery()
    {
        int allAttack = _enemyAttack + 10;// �}�W�b�N�i���o�[
        _playerData.MpRecovery(_mPRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// �̗͂��`�F�b�N����֐�
    /// </summary>
    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("�Q�[���I�[�o�[");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("�Q�[���N���A");
        }
        else
        {
            print("�܂��Q�[���͏I����Ă��Ȃ���I");
        }
    }

    /// <summary>
    /// MP���`�F�b�N����֐�
    /// </summary>
    void MPCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            print("MP������Ȃ���");
            return;
        }
    }

    #endregion
}
