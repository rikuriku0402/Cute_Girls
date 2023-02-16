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

    public int MPPortionRecovery => _mpRecovery;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("Player Data")]
    PlayerData _playerData;

    [SerializeField]
    [Header("Enemy Data")]
    private EnemyData _enemyData;

    [SerializeField]
    [Header("�h���")]
    private int _defence;

    [SerializeField]
    [Header("�v���C���[�U����")]
    private int _playerAttack;

    [SerializeField]
    [Header("�|�[�V�����U����")]
    private int _portionAttack;

    [SerializeField]
    [Header("�ǂ̂��炢MP���񕜂����邩")]
    private int _mpRecovery;

    [SerializeField]
    [Header("����MP")]
    private int _portionMp;

    [SerializeField]
    [Header("�G�̍U����")]
    private int _enemyAttack;

    [SerializeField]
    [Header("�o�g���L�����o�X")]
    private Canvas _BattleCanvas;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    #endregion

    #region Method

    /// <summary>
    /// �U������֐�
    /// </summary>
    public async UniTask Attack()
    {
        print("�G�ɍU��");
        _enemyData.HpDamage(_playerAttack);
        _uiManager.EnemyDamageTextPopUp(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1.2f));
        _uiManager.PlayerDamageTextPopUp(_enemyAttack);
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
        _enemyData.HpDamage(_portionAttack);
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
        _playerData.MpRecovery(_mpRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);

        if (_mpRecovery <= 150)
        {
            Debug.Log("MP�}�b�N�X");
            _playerData.Mp.Value = 150;
        }
        HpCheck();
    }

    /// <summary>
    /// �̗͂��`�F�b�N����֐�
    /// </summary>
    private void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("�Q�[���N���A");
            _enemyData.Init();
            CanvasFalse();
        }
        else
        {
            Debug.Log("�܂��Q�[���͏I����Ă��Ȃ���I");
        }
    }

    /// <summary>
    /// MP���`�F�b�N����֐�
    /// </summary>
    private void MPCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            return;
        }
    }

    /// <summary>
    /// �L�����o�X���\���ɂ���֐�
    /// </summary>
    private void CanvasFalse()
    {
        _BattleCanvas.gameObject.SetActive(false);
        GameManager.Instance.ChangeGameMode(true);
    }

    #endregion
}
