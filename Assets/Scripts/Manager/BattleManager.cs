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

    public int MagicAttack => _magicAttack;

    public int MPPortionRecovery => _mpRecovery;

    public int HPPoritonRecovery => _hpRecovery;

    public int AllDamage => _allDamage;

    #endregion

    #region Const

    const float WAIT_TIME = 1.2f;

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
    [Header("���@�U����")]
    private int _magicAttack;

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
    [Header("UIManager")]
    private UIManager _uiManager;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    [SerializeField]
    [Header("SceneManager")]
    private SceneLoader _sceneLoader;

    private int _allDamage;

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
        _uiManager.LogText.text = "Player���G��" + _playerAttack + "�^����";
        await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
        _uiManager.LogText.text = "�G��Player��" + _enemyAttack + "�^����";
        BattleCheck();
        _uiManager.PlayerDamageTextPopUp(_enemyAttack);
        _playerData.HpDamage(_enemyAttack);
        BattleCheck();
    }

    /// <summary>
    /// �h�䂷��֐�
    /// </summary>
    public async UniTask Defence()
    {

        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���"; 
            return;
        }
        else
        {
            _allDamage = 0;
            _soundManager.PlaySFX(SFXType.Defence);
            _playerData.MpDamage(_portionMp);
            Debug.Log("�h��");
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            BattleCheck();
            _allDamage = _enemyAttack - _defence;
            _uiManager.PlayerDamageTextPopUp(_allDamage);
            _playerData.HpDamage(_allDamage);
            _uiManager.LogText.text = "�h�䂵��" + _allDamage + "�������";
            BattleCheck();
        }
    }

    /// <summary>
    /// �|�[�V�����ōU������֐�
    /// </summary>
    public async UniTask Magic()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���";
            return;
        }
        else
        {
            _soundManager.PlaySFX(SFXType.Portion);
            _enemyData.HpDamage(_magicAttack);
            _playerData.MpDamage(_portionMp);
            _uiManager.EnemyDamageTextPopUp(_magicAttack);
            _uiManager.LogText.text = "Player���G��" + _magicAttack + "�^����";
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            _uiManager.LogText.text = "�G��Player��" + _enemyAttack + "�^����";
            BattleCheck();
            _uiManager.PlayerDamageTextPopUp(_enemyAttack);
            _playerData.HpDamage(_enemyAttack);
            BattleCheck();
        }
    }

    /// <summary>
    /// �|�[�V�������񕜂���֐�
    /// </summary>
    public async UniTask MPRecovery()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���";
            _playerData.Mp.Value = 0;
        }
        else if (_playerData.Mp.Value >= 150)
        {
            _playerData.Mp.Value = 150;
            _uiManager.LogText.text = "MP���}�b�N�X����";
            return;
        }

        _allDamage = 0;
        _soundManager.PlaySFX(SFXType.PoritionRecovery);
        _playerData.MpRecovery(_mpRecovery);
        _uiManager.LogText.text = "MP��" + _mpRecovery + "�񕜂���";
        await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
        _uiManager.LogText.text = "�G��Player��" + _allDamage + "�^����";
        BattleCheck();
        _allDamage = _enemyAttack + 3;// �}�W�b�N�i���o�[
        _uiManager.PlayerDamageTextPopUp(_allDamage);
        _playerData.HpDamage(_allDamage);

        if (_playerData.Mp.Value >= 150)
        {
            Debug.Log("MP�}�b�N�X");
            _playerData.Mp.Value = 150;
        }
        BattleCheck();
    }

    /// <summary>
    /// HP���񕜂���֐�
    /// </summary>
    public async UniTask HPRecovery()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            _uiManager.LogText.text = "MP������Ȃ���";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            _uiManager.LogText.text = "MP������Ȃ���";
            return;
        }
        else if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HP�}�b�N�X");
            _uiManager.LogText.text = "HP�}�b�N�X����";
            _playerData.Hp.Value = 100;
            return;
        }
        else
        {
            _allDamage = 0;

            _soundManager.PlaySFX(SFXType.HpRecovery);
            _allDamage = _enemyAttack + 3;// �}�W�b�N�i���o�[
            _playerData.MpDamage(_portionMp);
            _playerData.HpRecovery(_hpRecovery);

            if (_playerData.Hp.Value >= 100)
            {
                Debug.Log("HP�}�b�N�X");
                _uiManager.LogText.text = "HP�}�b�N�X����";
                _playerData.Hp.Value = 100;
            }

            _uiManager.LogText.text = "HP��" + _hpRecovery + "�񕜂���";
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            _uiManager.LogText.text = "�G��Player��" + _allDamage + "�^����";
            BattleCheck();
            _uiManager.PlayerDamageTextPopUp(_allDamage);
            _playerData.HpDamage(_allDamage);

            BattleCheck();
        }
    }

    /// <summary>
    /// �̗͂��`�F�b�N����
    /// �Q�[���N���A���Q�[���I�[�o�[����
    /// �Ď�����֐�
    /// </summary>
    private void BattleCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
            _soundManager.PlayBGM(BGMType.GameOver);
            _sceneLoader.FadeInSceneChange("GameOver");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("�Q�[���N���A");
            _soundManager.PlaySFX(SFXType.BattleWin);
            _soundManager.PlayBGM(BGMType.Game);
            _enemyData.Init();
            _uiManager.CanvasFalse();
        }
        else
        {
            Debug.Log("�܂��Q�[���͏I����Ă��Ȃ���I");
        }
    }

    private void HpCheck()
    {
        if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HP�}�b�N�X");
            _playerData.Hp.Value = 100;
            return;
        }
    }

    private void MpCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MP������Ȃ���");
            _playerData.Mp.Value = 0;
            return;
        }
    }

    #endregion
}
