using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerData : MonoBehaviour
{
    #region Property

    public IntReactiveProperty Hp => _hp;

    public IntReactiveProperty Mp => _mp;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("体力(HP)")]
    private IntReactiveProperty _hp = new();

    [SerializeField]
    [Header("マナポイント(MP)")]
    private IntReactiveProperty _mp = new();

    #endregion

    #region Unity Method

    public void OnDestroy()
    {
        Hp.Dispose();
        Mp.Dispose();
    }

    #endregion

    #region Method

    /// <summary>
    /// プレイヤーがダメージを受ける関数
    /// </summary>
    public void HpDamage(int anyValue) => Hp.Value -= anyValue;

    /// <summary>
    /// プレイヤーMpを減らす関数
    /// </summary>
    public void MpDamage(int anyValue) => Mp.Value -= anyValue;

    /// <summary>
    /// プレイヤーのポーションを回復する関数
    /// </summary>
    public void MpRecovery(int anyValue) => Mp.Value += anyValue;

    /// <summary>
    /// Hpを増やす関数
    /// </summary>
    public void HpRecovery(int anuValue) => Hp.Value += anuValue;
    #endregion
}