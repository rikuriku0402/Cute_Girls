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

    #endregion

    #region Method

    /// <summary>
    /// 攻撃する関数
    /// </summary>
    public async UniTask Attack()
    {
        print("敵に攻撃");
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
        MPCheck();
        int allAttack = _enemyAttack - 10;// マジックナンバー
        _playerData.MpDamage(_portionMp);
        print("防御");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// ポーションで攻撃する関数
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
    /// ポーションを回復する関数
    /// </summary>
    public async UniTask MPRecovery()
    {
        int allAttack = _enemyAttack + 10;// マジックナンバー
        _playerData.MpRecovery(_mpRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);

        if (_mpRecovery <= 150)
        {
            Debug.Log("MPマックス");
            _playerData.Mp.Value = 150;
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
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("ゲームクリア");
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
