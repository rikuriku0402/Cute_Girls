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

    public int HPPoritonRecovery => _hpRecovery;

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
    [Header("�ǂ̂��炢HP���񕜂����邩")]
    private int _hpRecovery;

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

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    #endregion

    #region Method

    /// <summary>
    /// �U������֐�
    /// </summary>
    public async UniTask Attack()
    {
        _soundManager.PlaySFX(SFXType.Attack);
        Debug.Log("�G�ɍU��");
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
        _soundManager.PlaySFX(SFXType.Defence);
        MPCheck();
        _playerData.MpDamage(_portionMp);
        print("�h��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        int allAttack = _enemyAttack - _defence;
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// �|�[�V�����ōU������֐�
    /// </summary>
    public async UniTask Portion()
    {
        _soundManager.PlaySFX(SFXType.Portion);
        MPCheck();
        _enemyData.HpDamage(_portionAttack);
        _uiManager.EnemyDamageTextPopUp(_portionAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _uiManager.PlayerDamageTextPopUp(_enemyAttack);
        _playerData.MpDamage(_portionMp);
        _playerData.HpDamage(_enemyAttack);
        HpCheck();
    }

    /// <summary>
    /// �|�[�V�������񕜂���֐�
    /// </summary>
    public async UniTask MPRecovery()
    {
        _soundManager.PlaySFX(SFXType.PoritionRecovery);
        _playerData.MpRecovery(_mpRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        int allAttack = _enemyAttack + 10;// �}�W�b�N�i���o�[
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);

        if (_playerData.Mp.Value >= 150)
        {
            Debug.Log("MP�}�b�N�X");
            _playerData.Mp.Value = 150;
        }
        HpCheck();
    }

    public async UniTask HPRecovery()
    {
        _soundManager.PlaySFX(SFXType.HpRecovery);
        int allAttack = _enemyAttack + 10;// �}�W�b�N�i���o�[
        _playerData.HpRecovery(_hpRecovery);
        _playerData.MpDamage(_portionMp);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);

        if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HP�}�b�N�X");
            _playerData.Hp.Value = 100;
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
            _soundManager.PlayBGM(BGMType.GameOver);
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("�Q�[���N���A");
            _soundManager.PlaySFX(SFXType.BattleWin);
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
