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
    /// 攻撃する関数
    /// </summary>
    public async UniTask Attack()
    {
        print("敵に攻撃");
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
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
        _enemyData.Damage(_portionAttack);
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
        _playerData.MpRecovery(_mPRecovery);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.HpDamage(allAttack);
        HpCheck();
    }

    /// <summary>
    /// 体力をチェックする関数
    /// </summary>
    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("ゲームオーバー");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("ゲームクリア");
        }
        else
        {
            print("まだゲームは終わっていないよ！");
        }
    }

    /// <summary>
    /// MPをチェックする関数
    /// </summary>
    void MPCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            print("MPが足りないよ");
            return;
        }
    }

    #endregion
}
