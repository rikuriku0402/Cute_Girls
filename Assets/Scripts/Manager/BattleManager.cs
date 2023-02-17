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
    [Header("防御力")]
    private int _defence;

    [SerializeField]
    [Header("プレイヤー攻撃力")]
    private int _playerAttack;

    [SerializeField]
    [Header("ポーション攻撃力")]
    private int _portionAttack;

    [SerializeField]
    [Header("どのくらいMPを回復させるか")]
    private int _mpRecovery;

    [SerializeField]
    [Header("どのくらいHPを回復させるか")]
    private int _hpRecovery;

    [SerializeField]
    [Header("消費MP")]
    private int _portionMp;

    [SerializeField]
    [Header("敵の攻撃力")]
    private int _enemyAttack;

    [SerializeField]
    [Header("バトルキャンバス")]
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
    /// 攻撃する関数
    /// </summary>
    public async UniTask Attack()
    {
        _soundManager.PlaySFX(SFXType.Attack);
        Debug.Log("敵に攻撃");
        _enemyData.HpDamage(_playerAttack);
        _uiManager.EnemyDamageTextPopUp(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1.2f));
        _uiManager.PlayerDamageTextPopUp(_enemyAttack);
        _playerData.HpDamage(_enemyAttack);
        HpCheck();
    }

    /// <summary>
    /// 防御する関数
    /// </summary>
    public async UniTask Defence()
    {
        _soundManager.PlaySFX(SFXType.Defence);
        MPCheck();
        _playerData.MpDamage(_portionMp);
        print("防御");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        int allAttack = _enemyAttack - _defence;
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// ポーションで攻撃する関数
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
    /// ポーションを回復する関数
    /// </summary>
    public async UniTask MPRecovery()
    {
        _soundManager.PlaySFX(SFXType.PoritionRecovery);
        _playerData.MpRecovery(_mpRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        int allAttack = _enemyAttack + 10;// マジックナンバー
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);

        if (_playerData.Mp.Value >= 150)
        {
            Debug.Log("MPマックス");
            _playerData.Mp.Value = 150;
        }
        HpCheck();
    }

    public async UniTask HPRecovery()
    {
        _soundManager.PlaySFX(SFXType.HpRecovery);
        int allAttack = _enemyAttack + 10;// マジックナンバー
        _playerData.HpRecovery(_hpRecovery);
        _playerData.MpDamage(_portionMp);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _uiManager.PlayerDamageTextPopUp(allAttack);
        _playerData.HpDamage(allAttack);

        if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HPマックス");
            _playerData.Hp.Value = 100;
        }
        HpCheck();
    }

    /// <summary>
    /// 体力をチェックする関数
    /// </summary>
    private void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            Debug.Log("ゲームオーバー");
            _soundManager.PlayBGM(BGMType.GameOver);
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("ゲームクリア");
            _soundManager.PlaySFX(SFXType.BattleWin);
            _enemyData.Init();
            CanvasFalse();
        }
        else
        {
            Debug.Log("まだゲームは終わっていないよ！");
        }
    }

    /// <summary>
    /// MPをチェックする関数
    /// </summary>
    private void MPCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            return;
        }
    }

    /// <summary>
    /// キャンバスを非表示にする関数
    /// </summary>
    private void CanvasFalse()
    {
        _BattleCanvas.gameObject.SetActive(false);
        GameManager.Instance.ChangeGameMode(true);
    }

    #endregion
}
